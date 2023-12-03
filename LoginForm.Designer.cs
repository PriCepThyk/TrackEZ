namespace TrackEZ
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btnLog = new Button();
            label1 = new Label();
            txtLogin = new TextBox();
            txtPsw = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnLog
            // 
            btnLog.AutoSize = true;
            btnLog.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLog.Location = new Point(138, 305);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(113, 43);
            btnLog.TabIndex = 1;
            btnLog.Text = "Увійти";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 128);
            label1.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(152, 81);
            label1.Name = "label1";
            label1.Size = new Size(84, 28);
            label1.TabIndex = 3;
            label1.Text = "Логін";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtLogin.Location = new Point(105, 128);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(186, 35);
            txtLogin.TabIndex = 4;
            txtLogin.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPsw
            // 
            txtPsw.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtPsw.Location = new Point(105, 229);
            txtPsw.Name = "txtPsw";
            txtPsw.Size = new Size(186, 35);
            txtPsw.TabIndex = 5;
            txtPsw.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 128);
            label2.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(140, 182);
            label2.Name = "label2";
            label2.Size = new Size(109, 28);
            label2.TabIndex = 6;
            label2.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(396, 398);
            Controls.Add(label2);
            Controls.Add(txtPsw);
            Controls.Add(txtLogin);
            Controls.Add(label1);
            Controls.Add(btnLog);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TrackEZ";
            FormClosing += Form1_FormClosing;
            KeyDown += LoginForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLog;
        private Label label1;
        private TextBox txtLogin;
        private TextBox txtPsw;
        private Label label2;
    }
}