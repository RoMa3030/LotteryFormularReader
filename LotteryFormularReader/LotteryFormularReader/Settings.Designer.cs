namespace LotteryFormularReader
{
    partial class Settings
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
            txt_1 = new TextBox();
            txt_2 = new TextBox();
            txt_3 = new TextBox();
            bt_Photo = new Button();
            bt_Recog = new Button();
            bt_Python = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            bt_cancel = new Button();
            bt_OK = new Button();
            SuspendLayout();
            // 
            // txt_1
            // 
            txt_1.Location = new Point(13, 73);
            txt_1.Name = "txt_1";
            txt_1.ReadOnly = true;
            txt_1.Size = new Size(635, 27);
            txt_1.TabIndex = 0;
            // 
            // txt_2
            // 
            txt_2.Location = new Point(12, 165);
            txt_2.Name = "txt_2";
            txt_2.ReadOnly = true;
            txt_2.Size = new Size(635, 27);
            txt_2.TabIndex = 1;
            // 
            // txt_3
            // 
            txt_3.Location = new Point(13, 252);
            txt_3.Name = "txt_3";
            txt_3.ReadOnly = true;
            txt_3.Size = new Size(635, 27);
            txt_3.TabIndex = 2;
            // 
            // bt_Photo
            // 
            bt_Photo.Location = new Point(553, 285);
            bt_Photo.Name = "bt_Photo";
            bt_Photo.Size = new Size(94, 29);
            bt_Photo.TabIndex = 3;
            bt_Photo.Text = "select";
            bt_Photo.UseVisualStyleBackColor = true;
            bt_Photo.Click += bt_Photo_Click;
            // 
            // bt_Recog
            // 
            bt_Recog.Location = new Point(553, 198);
            bt_Recog.Name = "bt_Recog";
            bt_Recog.Size = new Size(94, 29);
            bt_Recog.TabIndex = 4;
            bt_Recog.Text = "select";
            bt_Recog.UseVisualStyleBackColor = true;
            bt_Recog.Click += bt_Recog_Click;
            // 
            // bt_Python
            // 
            bt_Python.Location = new Point(554, 106);
            bt_Python.Name = "bt_Python";
            bt_Python.Size = new Size(94, 29);
            bt_Python.TabIndex = 5;
            bt_Python.Text = "select";
            bt_Python.UseVisualStyleBackColor = true;
            bt_Python.Click += bt_Python_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 6;
            label1.Text = "Link To Python";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 142);
            label2.Name = "label2";
            label2.Size = new Size(164, 20);
            label2.TabIndex = 7;
            label2.Text = "Link To Text Recognizer";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 229);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 8;
            label3.Text = "Link To Photo Shooter";
            // 
            // bt_cancel
            // 
            bt_cancel.Location = new Point(22, 341);
            bt_cancel.Name = "bt_cancel";
            bt_cancel.Size = new Size(94, 29);
            bt_cancel.TabIndex = 9;
            bt_cancel.Text = "Cancel";
            bt_cancel.UseVisualStyleBackColor = true;
            bt_cancel.Click += bt_cancel_Click;
            // 
            // bt_OK
            // 
            bt_OK.Location = new Point(133, 341);
            bt_OK.Name = "bt_OK";
            bt_OK.Size = new Size(94, 29);
            bt_OK.TabIndex = 10;
            bt_OK.Text = "Ok";
            bt_OK.UseVisualStyleBackColor = true;
            bt_OK.Click += bt_OK_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 382);
            Controls.Add(bt_OK);
            Controls.Add(bt_cancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bt_Python);
            Controls.Add(bt_Recog);
            Controls.Add(bt_Photo);
            Controls.Add(txt_3);
            Controls.Add(txt_2);
            Controls.Add(txt_1);
            Name = "Settings";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_1;
        private TextBox txt_2;
        private TextBox txt_3;
        private Button bt_Photo;
        private Button bt_Recog;
        private Button bt_Python;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button bt_cancel;
        private Button bt_OK;
    }
}