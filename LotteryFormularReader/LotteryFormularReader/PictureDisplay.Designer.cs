namespace LotteryFormularReader
{
    partial class PictureDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureDisplay));
            pb_Preview = new PictureBox();
            bt_UsePic = new Button();
            bt_Reshoot = new Button();
            bt_Esc = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_Preview).BeginInit();
            SuspendLayout();
            // 
            // pb_Preview
            // 
            pb_Preview.Location = new Point(12, 12);
            pb_Preview.Name = "pb_Preview";
            pb_Preview.Size = new Size(703, 462);
            pb_Preview.TabIndex = 0;
            pb_Preview.TabStop = false;
            // 
            // bt_UsePic
            // 
            bt_UsePic.Location = new Point(582, 481);
            bt_UsePic.Name = "bt_UsePic";
            bt_UsePic.Size = new Size(135, 29);
            bt_UsePic.TabIndex = 1;
            bt_UsePic.Text = "Ok";
            bt_UsePic.UseVisualStyleBackColor = true;
            bt_UsePic.Click += bt_UsePic_Click;
            // 
            // bt_Reshoot
            // 
            bt_Reshoot.Location = new Point(441, 480);
            bt_Reshoot.Name = "bt_Reshoot";
            bt_Reshoot.Size = new Size(135, 29);
            bt_Reshoot.TabIndex = 2;
            bt_Reshoot.Text = "Take New";
            bt_Reshoot.UseVisualStyleBackColor = true;
            bt_Reshoot.Click += bt_Reshoot_Click;
            // 
            // bt_Esc
            // 
            bt_Esc.Location = new Point(300, 480);
            bt_Esc.Name = "bt_Esc";
            bt_Esc.Size = new Size(135, 29);
            bt_Esc.TabIndex = 3;
            bt_Esc.Text = "Clear";
            bt_Esc.UseVisualStyleBackColor = true;
            bt_Esc.Click += bt_Esc_Click;
            // 
            // PictureDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 516);
            Controls.Add(bt_Esc);
            Controls.Add(bt_Reshoot);
            Controls.Add(bt_UsePic);
            Controls.Add(pb_Preview);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PictureDisplay";
            Text = "PictureDisplay";
            ((System.ComponentModel.ISupportInitialize)pb_Preview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_Preview;
        private Button bt_UsePic;
        private Button bt_Reshoot;
        private Button bt_Esc;
    }
}