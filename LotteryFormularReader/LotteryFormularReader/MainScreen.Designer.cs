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
            bt_SelPic = new Button();
            bt_SelFolder = new Button();
            bt_ShootPic = new Button();
            bt_Export = new Button();
            tbl_GuessList = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            Place = new DataGridViewTextBoxColumn();
            GuessVal = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)tbl_GuessList).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // bt_SelPic
            // 
            bt_SelPic.Location = new Point(15, 12);
            bt_SelPic.Name = "bt_SelPic";
            bt_SelPic.Size = new Size(148, 29);
            bt_SelPic.TabIndex = 2;
            bt_SelPic.Text = "Select Picture";
            bt_SelPic.UseVisualStyleBackColor = true;
            bt_SelPic.Click += bt_SelPic_Click;
            // 
            // bt_SelFolder
            // 
            bt_SelFolder.Location = new Point(186, 12);
            bt_SelFolder.Name = "bt_SelFolder";
            bt_SelFolder.Size = new Size(148, 29);
            bt_SelFolder.TabIndex = 3;
            bt_SelFolder.Text = "Select Folder";
            bt_SelFolder.UseVisualStyleBackColor = true;
            bt_SelFolder.Click += bt_SelFolder_Click;
            // 
            // bt_ShootPic
            // 
            bt_ShootPic.Location = new Point(364, 12);
            bt_ShootPic.Name = "bt_ShootPic";
            bt_ShootPic.Size = new Size(148, 29);
            bt_ShootPic.TabIndex = 4;
            bt_ShootPic.Text = "Shoot Picture";
            bt_ShootPic.UseVisualStyleBackColor = true;
            // 
            // bt_Export
            // 
            bt_Export.Location = new Point(15, 60);
            bt_Export.Name = "bt_Export";
            bt_Export.Size = new Size(148, 29);
            bt_Export.TabIndex = 5;
            bt_Export.Text = "Export List";
            bt_Export.UseVisualStyleBackColor = true;
            // 
            // tbl_GuessList
            // 
            tbl_GuessList.AllowUserToAddRows = false;
            tbl_GuessList.AllowUserToDeleteRows = false;
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
            tbl_GuessList.Dock = DockStyle.Fill;
            tbl_GuessList.Location = new Point(0, 0);
            tbl_GuessList.Name = "tbl_GuessList";
            tbl_GuessList.ReadOnly = true;
            tbl_GuessList.RowHeadersVisible = false;
            tbl_GuessList.RowHeadersWidth = 51;
            tbl_GuessList.ScrollBars = ScrollBars.Vertical;
            tbl_GuessList.Size = new Size(832, 308);
            tbl_GuessList.TabIndex = 6;
            // 
            // Name
            // 
            Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Name.FillWeight = 250F;
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // Place
            // 
            Place.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Place.FillWeight = 250F;
            Place.HeaderText = "Place";
            Place.MinimumWidth = 6;
            Place.Name = "Place";
            Place.ReadOnly = true;
            // 
            // GuessVal
            // 
            GuessVal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GuessVal.HeaderText = "Guess";
            GuessVal.MinimumWidth = 6;
            GuessVal.Name = "GuessVal";
            GuessVal.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(832, 433);
            panel1.TabIndex = 7;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 3, 3, 10);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(bt_SelPic);
            splitContainer1.Panel1.Controls.Add(bt_Export);
            splitContainer1.Panel1.Controls.Add(bt_SelFolder);
            splitContainer1.Panel1.Controls.Add(bt_ShootPic);
            splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbl_GuessList);
            splitContainer1.Panel2MinSize = 0;
            splitContainer1.Size = new Size(832, 433);
            splitContainer1.SplitterDistance = 121;
            splitContainer1.TabIndex = 6;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 433);
            Controls.Add(panel1);
            MinimumSize = new Size(540, 380);
            Name.Name = "MainScreen";
            Text = "Lottery Formular Reader";
            ((System.ComponentModel.ISupportInitialize)tbl_GuessList).EndInit();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button bt_SelPic;
        private Button bt_SelFolder;
        private Button bt_ShootPic;
        private Button bt_Export;
        private DataGridView tbl_GuessList;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Place;
        private DataGridViewTextBoxColumn GuessVal;
        private Panel panel1;
        private SplitContainer splitContainer1;
    }
}
