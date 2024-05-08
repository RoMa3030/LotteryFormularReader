using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryFormularReader
{
    public partial class Settings : Form
    {
        public bool OutputConfirmed = false;
        public string PythonPath = "";
        public string TextRecoPath = "";
        public string PhotoPath = "";
        public bool UsePhoneCam = true;

        public Settings()
        {
            InitializeComponent();
            rbt_UseWebcam.Checked = true;
        }

        private void bt_Python_Click(object sender, EventArgs e)
        {
            string path = SelectPath(".exe");
            if (path != null)
            {
                PythonPath = path;
                txt_1.Text = PythonPath;
            }

        }

        private void bt_Recog_Click(object sender, EventArgs e)
        {
            string path = SelectPath(".py");
            if (path != null)
            {
                TextRecoPath = path;
                txt_2.Text = TextRecoPath;
            }
        }

        private void bt_Photo_Click(object sender, EventArgs e)
        {
            string path = SelectPath(".py");
            if (path != null)
            {
                PhotoPath = path;
                txt_3.Text = PhotoPath;
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            if (rbt_UsePhone.Checked)
            {
                UsePhoneCam = true;
            }
            else
            {
                UsePhoneCam = false;
            }

            OutputConfirmed = true;
            this.Close();
        }

        private string SelectPath(string fileType)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"{fileType} Files (*{fileType})|*{fileType}|All files (*.*)|*.*";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                return selectedFilePath;
            }
            return "";
        }

        private void rbt_UsePhone_CheckedChanged(object sender, EventArgs e)
        {
            //OutputConfirmed = true;
        }
    }
}
