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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            bt_SelPic = new Button();
            bt_SelFolder = new Button();
            bt_ShootPic = new Button();
            bt_Export = new Button();
            tbl_GuessList = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            Place = new DataGridViewTextBoxColumn();
            GuessVal = new DataGridViewTextBoxColumn();
            panel_Buttons = new Panel();
            splitContainer1 = new SplitContainer();
            bt_Settings = new Button();
            lb_CellEdit = new Label();
            txt_Edit = new TextBox();
            bt_Clear = new Button();
            ctm_CellActions = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            editAllEqualsToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)tbl_GuessList).BeginInit();
            panel_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ctm_CellActions.SuspendLayout();
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
            bt_ShootPic.Click += bt_ShootPic_Click;
            // 
            // bt_Export
            // 
            bt_Export.Location = new Point(15, 56);
            bt_Export.Name = "bt_Export";
            bt_Export.Size = new Size(148, 29);
            bt_Export.TabIndex = 5;
            bt_Export.Text = "Export List";
            bt_Export.UseVisualStyleBackColor = true;
            bt_Export.Click += bt_Export_Click;
            // 
            // tbl_GuessList
            // 
            tbl_GuessList.AllowUserToAddRows = false;
            tbl_GuessList.AllowUserToDeleteRows = false;
            tbl_GuessList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tbl_GuessList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tbl_GuessList.ColumnHeadersHeight = 29;
            tbl_GuessList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            tbl_GuessList.CellMouseDown += tbl_GuessList_CellMouseDown;
            tbl_GuessList.KeyDown += tbl_GuessList_KeyDown;
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
            // panel_Buttons
            // 
            panel_Buttons.Controls.Add(splitContainer1);
            panel_Buttons.Dock = DockStyle.Fill;
            panel_Buttons.Location = new Point(0, 0);
            panel_Buttons.Name = "panel_Buttons";
            panel_Buttons.Size = new Size(832, 433);
            panel_Buttons.TabIndex = 7;
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
            splitContainer1.Panel1.Controls.Add(bt_Settings);
            splitContainer1.Panel1.Controls.Add(lb_CellEdit);
            splitContainer1.Panel1.Controls.Add(txt_Edit);
            splitContainer1.Panel1.Controls.Add(bt_Clear);
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
            // bt_Settings
            // 
            bt_Settings.Location = new Point(733, 12);
            bt_Settings.Name = "bt_Settings";
            bt_Settings.Size = new Size(87, 29);
            bt_Settings.TabIndex = 10;
            bt_Settings.Text = "Settings";
            bt_Settings.UseVisualStyleBackColor = true;
            bt_Settings.Click += bt_Settings_Click;
            // 
            // lb_CellEdit
            // 
            lb_CellEdit.AutoSize = true;
            lb_CellEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_CellEdit.ForeColor = Color.Red;
            lb_CellEdit.Location = new Point(433, 51);
            lb_CellEdit.Name = "lb_CellEdit";
            lb_CellEdit.Size = new Size(86, 20);
            lb_CellEdit.TabIndex = 9;
            lb_CellEdit.Text = "Correction:";
            lb_CellEdit.Visible = false;
            // 
            // txt_Edit
            // 
            txt_Edit.BackColor = Color.FromArgb(255, 192, 192);
            txt_Edit.Location = new Point(433, 74);
            txt_Edit.Name = "txt_Edit";
            txt_Edit.Size = new Size(303, 27);
            txt_Edit.TabIndex = 8;
            txt_Edit.Visible = false;
            txt_Edit.KeyDown += txt_Edit_KeyDown;
            // 
            // bt_Clear
            // 
            bt_Clear.Location = new Point(186, 56);
            bt_Clear.Name = "bt_Clear";
            bt_Clear.Size = new Size(148, 29);
            bt_Clear.TabIndex = 6;
            bt_Clear.Text = "Clear List";
            bt_Clear.UseVisualStyleBackColor = true;
            bt_Clear.Click += bt_Clear_Click;
            // 
            // ctm_CellActions
            // 
            ctm_CellActions.ImageScalingSize = new Size(20, 20);
            ctm_CellActions.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, editAllEqualsToolStripMenuItem, deleteToolStripMenuItem });
            ctm_CellActions.Name = "ctm_CellActions";
            ctm_CellActions.Size = new Size(174, 76);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(173, 24);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // editAllEqualsToolStripMenuItem
            // 
            editAllEqualsToolStripMenuItem.Name = "editAllEqualsToolStripMenuItem";
            editAllEqualsToolStripMenuItem.Size = new Size(173, 24);
            editAllEqualsToolStripMenuItem.Text = "Edit All Equals";
            editAllEqualsToolStripMenuItem.Click += editAllEqualsToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(173, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 433);
            Controls.Add(panel_Buttons);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(540, 380);
            Name.Name = "MainScreen";
            Text = "Lottery Formular Reader";
            KeyPress += MainScreen_KeyPress;
            ((System.ComponentModel.ISupportInitialize)tbl_GuessList).EndInit();
            panel_Buttons.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ctm_CellActions.ResumeLayout(false);
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
        private Panel panel_Buttons;
        private SplitContainer splitContainer1;
        private Button bt_Clear;
        private ContextMenuStrip ctm_CellActions;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private TextBox txt_Edit;
        private Label lb_CellEdit;
        private ToolStripMenuItem editAllEqualsToolStripMenuItem;
        private Button bt_Settings;
    }
}
