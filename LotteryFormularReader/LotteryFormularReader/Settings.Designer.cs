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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            rbt_UseWebcam = new RadioButton();
            rbt_UsePhone = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txt_1
            // 
            txt_1.Location = new Point(6, 53);
            txt_1.Name = "txt_1";
            txt_1.ReadOnly = true;
            txt_1.Size = new Size(635, 27);
            txt_1.TabIndex = 0;
            // 
            // txt_2
            // 
            txt_2.Location = new Point(6, 136);
            txt_2.Name = "txt_2";
            txt_2.ReadOnly = true;
            txt_2.Size = new Size(635, 27);
            txt_2.TabIndex = 1;
            // 
            // txt_3
            // 
            txt_3.Location = new Point(5, 220);
            txt_3.Name = "txt_3";
            txt_3.ReadOnly = true;
            txt_3.Size = new Size(635, 27);
            txt_3.TabIndex = 2;
            // 
            // bt_Photo
            // 
            bt_Photo.Location = new Point(545, 253);
            bt_Photo.Name = "bt_Photo";
            bt_Photo.Size = new Size(94, 29);
            bt_Photo.TabIndex = 3;
            bt_Photo.Text = "select";
            bt_Photo.UseVisualStyleBackColor = true;
            bt_Photo.Click += bt_Photo_Click;
            // 
            // bt_Recog
            // 
            bt_Recog.Location = new Point(547, 169);
            bt_Recog.Name = "bt_Recog";
            bt_Recog.Size = new Size(94, 29);
            bt_Recog.TabIndex = 4;
            bt_Recog.Text = "select";
            bt_Recog.UseVisualStyleBackColor = true;
            bt_Recog.Click += bt_Recog_Click;
            // 
            // bt_Python
            // 
            bt_Python.Location = new Point(547, 86);
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
            label1.Location = new Point(5, 30);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 6;
            label1.Text = "Link To Python";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 113);
            label2.Name = "label2";
            label2.Size = new Size(164, 20);
            label2.TabIndex = 7;
            label2.Text = "Link To Text Recognizer";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 197);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 8;
            label3.Text = "Link To Photo Shooter";
            // 
            // bt_cancel
            // 
            bt_cancel.Location = new Point(462, 415);
            bt_cancel.Name = "bt_cancel";
            bt_cancel.Size = new Size(94, 29);
            bt_cancel.TabIndex = 9;
            bt_cancel.Text = "Cancel";
            bt_cancel.UseVisualStyleBackColor = true;
            bt_cancel.Click += bt_cancel_Click;
            // 
            // bt_OK
            // 
            bt_OK.Location = new Point(573, 415);
            bt_OK.Name = "bt_OK";
            bt_OK.Size = new Size(94, 29);
            bt_OK.TabIndex = 10;
            bt_OK.Text = "Ok";
            bt_OK.UseVisualStyleBackColor = true;
            bt_OK.Click += bt_OK_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_1);
            groupBox1.Controls.Add(txt_2);
            groupBox1.Controls.Add(txt_3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(bt_Photo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(bt_Recog);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(bt_Python);
            groupBox1.Location = new Point(10, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(657, 292);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Paths";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbt_UseWebcam);
            groupBox2.Controls.Add(rbt_UsePhone);
            groupBox2.Location = new Point(10, 316);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(657, 80);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Devices";
            // 
            // rbt_UseWebcam
            // 
            rbt_UseWebcam.AutoSize = true;
            rbt_UseWebcam.Location = new Point(151, 26);
            rbt_UseWebcam.Name = "rbt_UseWebcam";
            rbt_UseWebcam.Size = new Size(116, 24);
            rbt_UseWebcam.TabIndex = 1;
            rbt_UseWebcam.TabStop = true;
            rbt_UseWebcam.Text = "Use Webcam";
            rbt_UseWebcam.UseVisualStyleBackColor = true;
            // 
            // rbt_UsePhone
            // 
            rbt_UsePhone.AutoSize = true;
            rbt_UsePhone.Location = new Point(6, 26);
            rbt_UsePhone.Name = "rbt_UsePhone";
            rbt_UsePhone.Size = new Size(139, 24);
            rbt_UsePhone.TabIndex = 0;
            rbt_UsePhone.TabStop = true;
            rbt_UsePhone.Text = "Use Smartphone";
            rbt_UsePhone.UseVisualStyleBackColor = true;
            rbt_UsePhone.CheckedChanged += rbt_UsePhone_CheckedChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 452);
            Controls.Add(groupBox2);
            Controls.Add(bt_cancel);
            Controls.Add(bt_OK);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Settings";
            Text = "Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton rbt_UsePhone;
        private RadioButton rbt_UseWebcam;
    }
}