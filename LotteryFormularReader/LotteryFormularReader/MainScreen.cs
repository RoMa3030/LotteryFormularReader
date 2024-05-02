using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LotteryFormularReader
{
    public partial class MainScreen : Form
    {
        List<int> LastClickedCell = new List<int>() { 0, 0 };
        private bool MultiCellEditModeActive = false;

        // default paths = paths for Roger's PC
        private string PythonPath = "C:\\Users\\Roger Mattle\\AppData\\Local\\Programs\\Python\\Python311\\python.exe";
        //private string TextRecoPath = "C:\\FHGR_Programme\\LotteryFormularReader\\FormularReader_ImageProcessing\\FormularReader_ImgProc.py";
        //private string PhotoPath = "C:\\FHGR_Programme\\LotteryFormularReader\\FormularReader_ImageProcessing\\FormularReader_ShootPicture.py";
        private string TextRecoPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "FormularReader_ImgProc.py");
        private string PhotoPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "FormularReader_ShootPicture.py");
        public MainScreen()
        {
            InitializeComponent();
        }

        #region Buttons
        private void bt_SelPic_Click(object sender, EventArgs e)
        {
            string path = PicPath_UserSelect();
            if (path != "ERROR")
            {
                ProcessPicture(path);
            }
            else
            {
                MessageBox.Show("An error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_SelFolder_Click(object sender, EventArgs e)
        {
            string path = FolderPath_UserSelect();
            ProcessAllPicsInFolder(path);
        }

        private void bt_ShootPic_Click(object sender, EventArgs e)
        {
            ShootNewPicture();
        }

        private void bt_Export_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string FolderPath = folderBrowserDialog.SelectedPath;
                ConvertTableContentToCsv(FolderPath);
            }

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiCellEditModeActive = false;
            StartCellEditing(LastClickedCell[0], LastClickedCell[1], false);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbl_GuessList.Rows.RemoveAt(LastClickedCell.ElementAt(0));
        }

        private void editAllEqualsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiCellEditModeActive = true;
            StartCellEditing(LastClickedCell[0], LastClickedCell[1], true);
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                                "You sure you want to clear the list?\nAll entries will be lost!",
                                                "Confirmation",
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                                                 );
            if (result == DialogResult.OK)
            {
                tbl_GuessList.Rows.Clear();
            }
        }
        #endregion

        #region FolderNavigation
        private string PicPath_UserSelect()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.gif,*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.FileName;
                return selectedFilePath;
            }
            return "ERROR";
        }

        private string FolderPath_UserSelect()
        {
            // Show folder browser dialog to select a folder
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Get the selected folder path
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                return selectedFolderPath;
            }
            else
            {
                MessageBox.Show("An error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR";
            }
        }
        #endregion

        #region PictureProcessing
        private void ProcessPicture(string PicturePath = "")
        {
            // On valid selection run python code and write results in table
            string ScriptPath = TextRecoPath;
            string ResultString = RunPythonScript(ScriptPath, PicturePath);
            List<GuessEntry> Guesses = EntriesParser(ResultString);
            WriteResultsInTable(Guesses);
        }

        private void ProcessAllPicsInFolder(string path)
        {
            if (path == "ERROR")
                return;
            // Iterate through all .png files in the selected folder
            string[] pngFiles = Directory.GetFiles(path, "*.png");
            foreach (string pngFile in pngFiles)
            {
                ProcessPicture(pngFile);
            }
        }

        private void ShootNewPicture()
        {
            string ScriptPath = PhotoPath;
            string PicturePath = Path.GetTempPath();
            PicturePath += "NewImg.png";

            RunPythonScript(ScriptPath, PicturePath);

            //ProcessPicture(PicturePath);
            PictureDisplay PreviewWindow = new PictureDisplay(PicturePath);
            PreviewWindow.Show();
            this.Enabled = false;

            PreviewWindow.FormClosed += (sender1, e1) =>
            {
                //Called on closing of PreviewWindow
                this.Enabled = true;
                switch (PreviewWindow.UserCommand)
                {
                    case 0: // Cancel
                        break;
                    case 1: // take new Picture
                        PreviewWindow.Dispose();
                        ShootNewPicture();
                        break;
                    case 2: // Picture Okay
                        ProcessPicture(PicturePath);
                        break;
                }
                if (File.Exists(PicturePath))
                {
                    File.Delete(PicturePath);
                }
            };
        }
        #endregion

        #region TableActions
        private void WriteResultsInTable(List<GuessEntry> Guesses)
        {
            int rows = tbl_GuessList.RowCount;
            if (Guesses.Count() == 0)    // don't do when no names recognized
            {
                MessageBox.Show("Could not find any valid data in picture!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbl_GuessList.Rows.Add(Guesses.Count());
            foreach (GuessEntry entry in Guesses)
            {
                tbl_GuessList.Rows[rows].Cells[0].Value = entry.Name;
                tbl_GuessList.Rows[rows].Cells[1].Value = entry.Town;
                tbl_GuessList.Rows[rows].Cells[2].Value = entry.GuessVal;
                rows++;
            }
        }

        List<GuessEntry> EntriesParser(string result)
        {
            List<GuessEntry> Guesses = new List<GuessEntry>();
            GuessEntry cacheGuess = new GuessEntry();
            string cache = "";
            int count = 0;
            foreach (char c in result)
            {
                switch (c)
                {
                    case ',':
                        // One field of the entry is complete
                        switch (count)
                        {
                            case 0:
                                cacheGuess.Name = cache;
                                break;
                            case 1:
                                cacheGuess.Town = cache;
                                break;
                        }
                        cache = "";
                        count++;
                        break;
                    case ';':
                        //One guess is read completely
                        cacheGuess.GuessVal = cache;
                        Guesses.Add(cacheGuess.deepCopy());
                        count = 0;
                        cache = "";
                        break;
                    case '\r':
                        result = "";
                        break;
                    default:
                        // just a further character in the string
                        cache = cache + c;
                        break;
                }
            }
            return Guesses;
        }

        private void ConvertTableContentToCsv(string FolderPath)
        {
            string FilePath = FolderPath + "\\LotteryGuessesExport_" + DateTime.Now.ToString("dd.MM.yyyy") + "_" + DateTime.Now.ToString("hh.mm.ss") + ".csv";

            // Create or overwrite the CSV file and write data to it
            using (StreamWriter writer = new StreamWriter(FilePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Name, Place, Guess");
                foreach (DataGridViewRow row in tbl_GuessList.Rows)
                {
                    string LineContent = row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() + "," + row.Cells[2].Value.ToString();
                    writer.WriteLine(LineContent);
                }
            }
        }

        private void StartCellEditing(int row, int col, bool AdaptMultipleCells)
        {
            AdaptVisibilityOnEditControlls(true);
            string LastCellContent = tbl_GuessList.Rows[LastClickedCell[0]].Cells[LastClickedCell[1]].Value.ToString();
            txt_Edit.Text = LastCellContent;
            lb_CellEdit.Visible = true;
            // Try to place textfield next to field to edit (not working yet)
            /*Rectangle cellDisplayRect = tbl_GuessList.GetCellDisplayRectangle(col, row, false);
            txt_Edit.Location = cellDisplayRect.Location;
            txt_Edit.BringToFront();    */
            txt_Edit.Select();          // Put UserCursor in textField
        }

        private void tbl_GuessList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctm_CellActions.Show(Control.MousePosition);        // open dropdown menu on mouse position
                LastClickedCell[0] = e.RowIndex;
                LastClickedCell[1] = e.ColumnIndex;
                //HighlightSelectedCell(LastClickedCell[0], LastClickedCell[1]);   // change color of selected cell
            }
        }
        #endregion

        #region PythonInterface
        private string RunPythonScript(string ScriptPath, string arg = "")
        {
            string pythonInterpreter = PythonPath;
            string pythonScript = ScriptPath;

            // Create a ProcessStartInfo object to configure the process
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = pythonInterpreter;         // Set the filename (Python interpreter)
            //startInfo.Arguments = pythonScript;             // Set the arguments (Python script)
            startInfo.Arguments = $"\"{pythonScript}\" \"{arg}\"";
            startInfo.UseShellExecute = false;              // Ensure that we can redirect input/output
            startInfo.RedirectStandardOutput = true;        // Redirect standard output
            startInfo.RedirectStandardError = true; //GPT

            // Create and start the process
            Process process = new Process();
            process.StartInfo = startInfo;
            try
            {
                process.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not start Process.\nMake sure paths are correct in SETTINGS!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            // Read the output of the Python script
            string Output = process.StandardError.ReadToEnd();
            Output += process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();
            Debug.WriteLine(Output);
            return Output;
        }

        #endregion

        #region KeyActions
        private void MainScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine(e.KeyChar);
        }

        private void tbl_GuessList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;   //prevent cursor from Jumpin to next cell automatically
                LastClickedCell[0] = tbl_GuessList.CurrentCell.RowIndex;
                LastClickedCell[1] = tbl_GuessList.CurrentCell.ColumnIndex;
                MultiCellEditModeActive = false;
                StartCellEditing(LastClickedCell[0], LastClickedCell[1], false);
            }
        }

        private void txt_Edit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Enter):
                    string oldText = tbl_GuessList.Rows[LastClickedCell[0]].Cells[LastClickedCell[1]].Value.ToString();
                    string newText = txt_Edit.Text;

                    tbl_GuessList.Rows[LastClickedCell[0]].Cells[LastClickedCell[1]].Value = newText;
                    txt_Edit.Text = "";
                    AdaptVisibilityOnEditControlls(false);

                    if (MultiCellEditModeActive)
                    {
                        if (LastClickedCell[1] != 2)        // do not allow to do this, if the guess is being edited
                        {                                   // to not corrupt old results with same guess.
                            ChangeAllCellsWithSameContent(oldText, newText);
                        }
                    }
                    break;
                case (Keys.Delete):
                    txt_Edit.Text = "";
                    break;
                case (Keys.Escape):
                    txt_Edit.Text = "";
                    AdaptVisibilityOnEditControlls(false);
                    break;
            }
        }
        #endregion

        private void ChangeAllCellsWithSameContent(string oldText, string newText)
        {
            foreach (DataGridViewRow row in tbl_GuessList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString() == oldText)
                    {
                        cell.Value = newText;
                    }
                }
            }
        }

        #region DesignAdaptions
        private void HighlightSelectedCell(int row, int col)
        {
            foreach (DataGridViewRow ROW in tbl_GuessList.Rows)
            {
                foreach (DataGridViewCell CELL in ROW.Cells)
                {
                    if (CELL.ColumnIndex == col && CELL.RowIndex == row)
                    {
                        CELL.Style.BackColor = Color.Gray; //Deafult color
                    }
                    else
                    {
                        CELL.Style.BackColor = Color.White; //Deafult color
                    }
                }
            }
        }

        private void AdaptVisibilityOnEditControlls(bool Vis)
        {
            if (Vis == true)
            {
                txt_Edit.Visible = true;
                lb_CellEdit.Visible = true;
            }
            else
            {
                txt_Edit.Visible = false;
                lb_CellEdit.Visible = false;
            }
        }
        #endregion

        private void bt_Settings_Click(object sender, EventArgs e)
        {
            Settings SettingsPage = new Settings();
            SettingsPage.Show();
            this.Enabled = false;

            SettingsPage.FormClosed += (sender1, e1) =>
            {
                //Called on closing of PreviewWindow
                this.Enabled = true;
                if(SettingsPage.OutputConfirmed == true)
                {
                    if (SettingsPage.PythonPath != null)
                    {
                        PythonPath = SettingsPage.PythonPath;
                    }
                    if (SettingsPage.TextRecoPath != null)
                    {
                        TextRecoPath = SettingsPage.TextRecoPath;
                    }
                    if (SettingsPage.PhotoPath != null)
                    {
                        PhotoPath = SettingsPage.PhotoPath;
                    }
                }
            };

        }
    }

    class GuessEntry
    {
        public string Name = "";
        public string Town = "";
        public string GuessVal ="";

        public GuessEntry deepCopy()
        {
            GuessEntry newGuess = new GuessEntry
            {
                Name = this.Name,
                Town = this.Town,
                GuessVal = this.GuessVal
            };
            return newGuess;
        }
    }
}
