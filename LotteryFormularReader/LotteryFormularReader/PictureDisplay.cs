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
    public partial class PictureDisplay : Form
    {
        public int UserCommand = 0; // 0 = esc / 1= reshoot / 2= UsePic

        public PictureDisplay(string path)
        {
            InitializeComponent();
            pb_Preview.ImageLocation = path;
        }

        private void bt_UsePic_Click(object sender, EventArgs e)
        {
            UserCommand = 2;
            this.Close();
        }

        private void bt_Reshoot_Click(object sender, EventArgs e)
        {
            UserCommand = 1;
            this.Close();
        }

        private void bt_Esc_Click(object sender, EventArgs e)
        {
            UserCommand = 0;
            this.Close();
        }
    }
}
