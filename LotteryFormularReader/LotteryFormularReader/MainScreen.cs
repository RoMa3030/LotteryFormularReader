using System.Diagnostics;
using System.IO;

namespace LotteryFormularReader
{
    public partial class MainScreen : Form
    {
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
            FolderPath_UserSelect();
        }
        #endregion


        private void ProcessPicture(string arg = "")
        {
            // On valid selection run python code and write results in table
            string ResultString = RunPythonScript(arg);
            List<GuessEntry> Guesses = EntriesParser(ResultString);
            WriteResultsInTable(Guesses);
        }

        private string RunPythonScript(string arg = "")
        {
            string pythonInterpreter = "python";
            //ToDo: Adapt to relative path
            string pythonScript = "C:\\FHGR_Programme\\LotteryFormularReader\\FormularReader_ImageProcessing\\FormularReader_ImgProc.py";
            //string pythonScript = "\\..\\..\\..\\..\\..\\FormularReader_ImageProcessing\\FormularReader_ImgProc.py";

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
            process.Start();

            // Read the output of the Python script
            string Output = process.StandardError.ReadToEnd();
            Output += process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();
            return Output;
        }

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

        private void FolderPath_UserSelect()
        {
            // Show folder browser dialog to select a folder
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Get the selected folder path
                string selectedFolderPath = folderBrowserDialog.SelectedPath;

                // Iterate through all .png files in the selected folder
                string[] pngFiles = Directory.GetFiles(selectedFolderPath, "*.png");
                foreach (string pngFile in pngFiles)
                {
                    ProcessPicture(pngFile);
                }
            }
            else
            {
                MessageBox.Show("An error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteResultsInTable(List<GuessEntry> Guesses)
        {
            int rows = tbl_GuessList.RowCount;
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
