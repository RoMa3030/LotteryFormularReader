namespace LotteryFormularReader
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txt_Output = new TextBox();
            button1 = new Button();
            bt_SelPic = new Button();
            bt_SelFolder = new Button();
            bt_ShootPic = new Button();
            bt_Export = new Button();
            tbl_GuessList = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            Place = new DataGridViewTextBoxColumn();
            GuessVal = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)tbl_GuessList).BeginInit();
            SuspendLayout();
            // 
            // txt_Output
            // 
            txt_Output.Location = new Point(12, 322);
            txt_Output.Multiline = true;
            txt_Output.Name = "txt_Output";
            txt_Output.Size = new Size(776, 116);
            txt_Output.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(640, 12);
            button1.Name = "button1";
            button1.Size = new Size(148, 29);
            button1.TabIndex = 1;
            button1.Text = "Python Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // bt_SelPic
            // 
            bt_SelPic.Location = new Point(12, 12);
            bt_SelPic.Name = "bt_SelPic";
            bt_SelPic.Size = new Size(148, 29);
            bt_SelPic.TabIndex = 2;
            bt_SelPic.Text = "Select Picture";
            bt_SelPic.UseVisualStyleBackColor = true;
            bt_SelPic.Click += bt_SelPic_Click;
            // 
            // bt_SelFolder
            // 
            bt_SelFolder.Location = new Point(182, 12);
            bt_SelFolder.Name = "bt_SelFolder";
            bt_SelFolder.Size = new Size(148, 29);
            bt_SelFolder.TabIndex = 3;
            bt_SelFolder.Text = "Select Folder";
            bt_SelFolder.UseVisualStyleBackColor = true;
            // 
            // bt_ShootPic
            // 
            bt_ShootPic.Location = new Point(353, 12);
            bt_ShootPic.Name = "bt_ShootPic";
            bt_ShootPic.Size = new Size(148, 29);
            bt_ShootPic.TabIndex = 4;
            bt_ShootPic.Text = "Shoot Picture";
            bt_ShootPic.UseVisualStyleBackColor = true;
            // 
            // bt_Export
            // 
            bt_Export.Location = new Point(12, 58);
            bt_Export.Name = "bt_Export";
            bt_Export.Size = new Size(148, 29);
            bt_Export.TabIndex = 5;
            bt_Export.Text = "Export List";
            bt_Export.UseVisualStyleBackColor = true;
            // 
            // tbl_GuessList
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tbl_GuessList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tbl_GuessList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tbl_GuessList.Columns.AddRange(new DataGridViewColumn[] { Name, Place, GuessVal });
            tbl_GuessList.Location = new Point(12, 128);
            tbl_GuessList.Name = "tbl_GuessList";
            tbl_GuessList.RowHeadersWidth = 51;
            tbl_GuessList.Size = new Size(776, 188);
            tbl_GuessList.TabIndex = 6;
            // 
            // Name
            // 
            Name.FillWeight = 250F;
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.Width = 125;
            // 
            // Place
            // 
            Place.FillWeight = 200F;
            Place.HeaderText = "Place";
            Place.MinimumWidth = 6;
            Place.Name = "Place";
            Place.Width = 125;
            // 
            // GuessVal
            // 
            GuessVal.HeaderText = "Guess";
            GuessVal.MinimumWidth = 6;
            GuessVal.Name = "GuessVal";
            GuessVal.Width = 125;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbl_GuessList);
            Controls.Add(bt_Export);
            Controls.Add(bt_ShootPic);
            Controls.Add(bt_SelFolder);
            Controls.Add(bt_SelPic);
            Controls.Add(button1);
            Controls.Add(txt_Output);
            Name = "MainScreen";
            Text = "Lottery Formular Reader";
            ((System.ComponentModel.ISupportInitialize)tbl_GuessList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Output;
        private Button button1;
        private Button bt_SelPic;
        private Button bt_SelFolder;
        private Button bt_ShootPic;
        private Button bt_Export;
        private DataGridView tbl_GuessList;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Place;
        private DataGridViewTextBoxColumn GuessVal;
    }
}
