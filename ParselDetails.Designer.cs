namespace TrackEZ
{
    partial class ParselDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParselDetails));
            btnBack = new Button();
            btnAdd = new Button();
            txtID = new TextBox();
            lbID = new Label();
            txtFirstNS = new TextBox();
            label1 = new Label();
            txtLastNS = new TextBox();
            label2 = new Label();
            txtMidlNS = new TextBox();
            label3 = new Label();
            txtFirstNR = new TextBox();
            label4 = new Label();
            txtLastNR = new TextBox();
            label5 = new Label();
            txtMidlNR = new TextBox();
            label6 = new Label();
            txtNumS = new TextBox();
            label10 = new Label();
            txtWeight = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtCost = new TextBox();
            label14 = new Label();
            groupBox1 = new GroupBox();
            label19 = new Label();
            groupBox2 = new GroupBox();
            label20 = new Label();
            txtNumR = new TextBox();
            comBoxReg = new ComboBox();
            groupBox3 = new GroupBox();
            label18 = new Label();
            comBoxOfNum = new ComboBox();
            label17 = new Label();
            comBoxCity = new ComboBox();
            groupBox4 = new GroupBox();
            label8 = new Label();
            comBoxPStatus = new ComboBox();
            comBoxParType = new ComboBox();
            label7 = new Label();
            comBoxStatus = new ComboBox();
            btnUpd = new Button();
            btnDel = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.AutoSize = true;
            btnBack.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(12, 429);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(136, 38);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(256, 429);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 38);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtID
            // 
            txtID.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtID.Location = new Point(58, 6);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(186, 35);
            txtID.TabIndex = 9;
            txtID.TextAlign = HorizontalAlignment.Center;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.BackColor = Color.FromArgb(0, 0, 0, 128);
            lbID.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbID.Location = new Point(12, 9);
            lbID.Name = "lbID";
            lbID.Size = new Size(40, 28);
            lbID.TabIndex = 8;
            lbID.Text = "ID";
            // 
            // txtFirstNS
            // 
            txtFirstNS.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFirstNS.Location = new Point(163, 77);
            txtFirstNS.Name = "txtFirstNS";
            txtFirstNS.Size = new Size(209, 32);
            txtFirstNS.TabIndex = 11;
            txtFirstNS.TextAlign = HorizontalAlignment.Center;
            txtFirstNS.Enter += txtFirstNS_Enter;
            txtFirstNS.Leave += txtFirstNS_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 128);
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(110, 25);
            label1.TabIndex = 10;
            label1.Text = "Прізвище";
            // 
            // txtLastNS
            // 
            txtLastNS.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLastNS.Location = new Point(163, 38);
            txtLastNS.Name = "txtLastNS";
            txtLastNS.Size = new Size(209, 32);
            txtLastNS.TabIndex = 13;
            txtLastNS.TextAlign = HorizontalAlignment.Center;
            txtLastNS.Enter += txtLastNS_Enter;
            txtLastNS.Leave += txtLastNS_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 128);
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 80);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 12;
            label2.Text = "Ім'я";
            // 
            // txtMidlNS
            // 
            txtMidlNS.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMidlNS.Location = new Point(163, 116);
            txtMidlNS.Name = "txtMidlNS";
            txtMidlNS.Size = new Size(209, 32);
            txtMidlNS.TabIndex = 15;
            txtMidlNS.TextAlign = HorizontalAlignment.Center;
            txtMidlNS.Enter += txtMidlNS_Enter;
            txtMidlNS.Leave += txtMidlNS_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 128);
            label3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 119);
            label3.Name = "label3";
            label3.Size = new Size(133, 25);
            label3.TabIndex = 14;
            label3.Text = "По батькові";
            // 
            // txtFirstNR
            // 
            txtFirstNR.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFirstNR.Location = new Point(163, 77);
            txtFirstNR.Name = "txtFirstNR";
            txtFirstNR.Size = new Size(209, 32);
            txtFirstNR.TabIndex = 17;
            txtFirstNR.TextAlign = HorizontalAlignment.Center;
            txtFirstNR.Enter += txtFirstNR_Enter;
            txtFirstNR.Leave += txtFirstNR_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 0, 128);
            label4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 119);
            label4.Name = "label4";
            label4.Size = new Size(133, 25);
            label4.TabIndex = 16;
            label4.Text = "По батькові";
            // 
            // txtLastNR
            // 
            txtLastNR.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLastNR.Location = new Point(163, 38);
            txtLastNR.Name = "txtLastNR";
            txtLastNR.Size = new Size(209, 32);
            txtLastNR.TabIndex = 19;
            txtLastNR.TextAlign = HorizontalAlignment.Center;
            txtLastNR.Enter += txtLastNR_Enter;
            txtLastNR.Leave += txtLastNR_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(0, 0, 0, 128);
            label5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 41);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 18;
            label5.Text = "Прізвище";
            // 
            // txtMidlNR
            // 
            txtMidlNR.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMidlNR.Location = new Point(163, 116);
            txtMidlNR.Name = "txtMidlNR";
            txtMidlNR.Size = new Size(209, 32);
            txtMidlNR.TabIndex = 21;
            txtMidlNR.TextAlign = HorizontalAlignment.Center;
            txtMidlNR.Enter += txtMidlNR_Enter;
            txtMidlNR.Leave += txtMidlNR_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(0, 0, 0, 128);
            label6.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 80);
            label6.Name = "label6";
            label6.Size = new Size(51, 25);
            label6.TabIndex = 20;
            label6.Text = "Ім'я";
            // 
            // txtNumS
            // 
            txtNumS.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumS.Location = new Point(163, 157);
            txtNumS.Name = "txtNumS";
            txtNumS.Size = new Size(209, 32);
            txtNumS.TabIndex = 23;
            txtNumS.TextAlign = HorizontalAlignment.Center;
            txtNumS.Enter += txtNumS_Enter;
            txtNumS.Leave += txtNumS_Leave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(0, 0, 0, 128);
            label10.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(6, 41);
            label10.Name = "label10";
            label10.Size = new Size(96, 25);
            label10.TabIndex = 28;
            label10.Text = "Область";
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtWeight.Location = new Point(74, 38);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(69, 32);
            txtWeight.TabIndex = 31;
            txtWeight.TextAlign = HorizontalAlignment.Center;
            txtWeight.Enter += txtWeight_Enter;
            txtWeight.Leave += txtWeight_Leave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(0, 0, 0, 128);
            label11.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(6, 41);
            label11.Name = "label11";
            label11.Size = new Size(59, 25);
            label11.TabIndex = 30;
            label11.Text = "Вага";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.FromArgb(0, 0, 0, 128);
            label12.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(6, 83);
            label12.Name = "label12";
            label12.Size = new Size(160, 25);
            label12.TabIndex = 32;
            label12.Text = "Статус оплати";
            // 
            // txtCost
            // 
            txtCost.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCost.Location = new Point(242, 39);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(130, 32);
            txtCost.TabIndex = 37;
            txtCost.TextAlign = HorizontalAlignment.Center;
            txtCost.Enter += txtCost_Enter;
            txtCost.Leave += txtCost_Leave;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.FromArgb(0, 0, 0, 128);
            label14.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(175, 41);
            label14.Name = "label14";
            label14.Size = new Size(65, 28);
            label14.TabIndex = 36;
            label14.Text = "Ціна";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtFirstNS);
            groupBox1.Controls.Add(txtLastNS);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMidlNS);
            groupBox1.Controls.Add(txtNumS);
            groupBox1.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 199);
            groupBox1.TabIndex = 42;
            groupBox1.TabStop = false;
            groupBox1.Text = "Відправник";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.FromArgb(0, 0, 0, 128);
            label19.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(6, 160);
            label19.Name = "label19";
            label19.Size = new Size(77, 25);
            label19.TabIndex = 24;
            label19.Text = "Номер";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtNumR);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtFirstNR);
            groupBox2.Controls.Add(txtLastNR);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtMidlNR);
            groupBox2.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(410, 47);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(378, 200);
            groupBox2.TabIndex = 43;
            groupBox2.TabStop = false;
            groupBox2.Text = "Отримувач";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.FromArgb(0, 0, 0, 128);
            label20.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(6, 160);
            label20.Name = "label20";
            label20.Size = new Size(77, 25);
            label20.TabIndex = 26;
            label20.Text = "Номер";
            // 
            // txtNumR
            // 
            txtNumR.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumR.Location = new Point(163, 157);
            txtNumR.Name = "txtNumR";
            txtNumR.Size = new Size(209, 32);
            txtNumR.TabIndex = 25;
            txtNumR.TextAlign = HorizontalAlignment.Center;
            txtNumR.Enter += txtNumR_Enter;
            txtNumR.Leave += txtNumR_Leave;
            // 
            // comBoxReg
            // 
            comBoxReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxReg.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxReg.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxReg.FormattingEnabled = true;
            comBoxReg.Location = new Point(120, 38);
            comBoxReg.Name = "comBoxReg";
            comBoxReg.Size = new Size(252, 33);
            comBoxReg.TabIndex = 44;
            comBoxReg.TextChanged += comBoxReg_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(comBoxOfNum);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(comBoxCity);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(comBoxReg);
            groupBox3.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(12, 256);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(378, 166);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            groupBox3.Text = "Адреса доставки";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.FromArgb(0, 0, 0, 128);
            label18.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(6, 125);
            label18.Name = "label18";
            label18.Size = new Size(124, 25);
            label18.TabIndex = 47;
            label18.Text = "Відділення";
            // 
            // comBoxOfNum
            // 
            comBoxOfNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxOfNum.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxOfNum.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxOfNum.FormattingEnabled = true;
            comBoxOfNum.Location = new Point(165, 122);
            comBoxOfNum.Name = "comBoxOfNum";
            comBoxOfNum.Size = new Size(207, 33);
            comBoxOfNum.TabIndex = 48;
            comBoxOfNum.TextChanged += comBoxOfNum_TextChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.FromArgb(0, 0, 0, 128);
            label17.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(6, 83);
            label17.Name = "label17";
            label17.Size = new Size(68, 25);
            label17.TabIndex = 45;
            label17.Text = "Місто";
            // 
            // comBoxCity
            // 
            comBoxCity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxCity.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxCity.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxCity.FormattingEnabled = true;
            comBoxCity.Location = new Point(120, 80);
            comBoxCity.Name = "comBoxCity";
            comBoxCity.Size = new Size(252, 33);
            comBoxCity.TabIndex = 46;
            comBoxCity.TextChanged += comBoxCity_TextChanged;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(comBoxPStatus);
            groupBox4.Controls.Add(comBoxParType);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(comBoxStatus);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(txtWeight);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(txtCost);
            groupBox4.Controls.Add(label14);
            groupBox4.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.Location = new Point(410, 256);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(378, 217);
            groupBox4.TabIndex = 49;
            groupBox4.TabStop = false;
            groupBox4.Text = "Інформація";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(0, 0, 0, 128);
            label8.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 125);
            label8.Name = "label8";
            label8.Size = new Size(81, 25);
            label8.TabIndex = 53;
            label8.Text = "Статус";
            // 
            // comBoxPStatus
            // 
            comBoxPStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxPStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxPStatus.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxPStatus.FormattingEnabled = true;
            comBoxPStatus.Items.AddRange(new object[] { "Оплачено", "Не оплачено" });
            comBoxPStatus.Location = new Point(193, 80);
            comBoxPStatus.Name = "comBoxPStatus";
            comBoxPStatus.Size = new Size(179, 33);
            comBoxPStatus.TabIndex = 52;
            comBoxPStatus.TextChanged += comBoxPStatus_TextChanged;
            // 
            // comBoxParType
            // 
            comBoxParType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxParType.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxParType.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxParType.FormattingEnabled = true;
            comBoxParType.Items.AddRange(new object[] { "Документи", "Електроніка", "Крихка" });
            comBoxParType.Location = new Point(125, 167);
            comBoxParType.Name = "comBoxParType";
            comBoxParType.Size = new Size(247, 33);
            comBoxParType.TabIndex = 51;
            comBoxParType.TextChanged += comBoxParType_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(0, 0, 0, 128);
            label7.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(8, 170);
            label7.Name = "label7";
            label7.Size = new Size(50, 25);
            label7.TabIndex = 50;
            label7.Text = "Тип";
            // 
            // comBoxStatus
            // 
            comBoxStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxStatus.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxStatus.FormattingEnabled = true;
            comBoxStatus.Items.AddRange(new object[] { "Доставлено", "В дорозі", "Отримано" });
            comBoxStatus.Location = new Point(163, 122);
            comBoxStatus.Name = "comBoxStatus";
            comBoxStatus.Size = new Size(209, 33);
            comBoxStatus.TabIndex = 49;
            comBoxStatus.TextChanged += comBoxStatus_TextChanged;
            // 
            // btnUpd
            // 
            btnUpd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpd.AutoSize = true;
            btnUpd.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpd.Location = new Point(256, 429);
            btnUpd.Name = "btnUpd";
            btnUpd.Size = new Size(136, 38);
            btnUpd.TabIndex = 50;
            btnUpd.Text = "Оновити";
            btnUpd.UseVisualStyleBackColor = true;
            btnUpd.Click += btnUpd_Click;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDel.AutoSize = true;
            btnDel.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDel.Location = new Point(187, 429);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(38, 38);
            btnDel.TabIndex = 51;
            btnDel.Text = "X";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // ParselDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(797, 479);
            ControlBox = false;
            Controls.Add(btnDel);
            Controls.Add(btnUpd);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtID);
            Controls.Add(lbID);
            Controls.Add(btnAdd);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimizeBox = false;
            Name = "ParselDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            FormClosing += ParselDetails_FormClosing;
            KeyDown += ParselDetails_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnAdd;
        private TextBox txtID;
        private Label lbID;
        private TextBox txtFirstNS;
        private Label label1;
        private TextBox txtLastNS;
        private Label label2;
        private TextBox txtMidlNS;
        private Label label3;
        private TextBox txtFirstNR;
        private Label label4;
        private TextBox txtLastNR;
        private Label label5;
        private TextBox txtMidlNR;
        private Label label6;
        private TextBox txtNumS;
        private Label label10;
        private TextBox txtWeight;
        private Label label11;
        private Label label12;
        private TextBox txtCost;
        private Label label14;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox comBoxReg;
        private GroupBox groupBox3;
        private Label label18;
        private ComboBox comBoxOfNum;
        private Label label17;
        private ComboBox comBoxCity;
        private GroupBox groupBox4;
        private Label label19;
        private Label label20;
        private TextBox txtNumR;
        private ComboBox comBoxStatus;
        private ComboBox comBoxParType;
        private Label label7;
        private ComboBox comBoxPStatus;
        private Label label8;
        private Button btnUpd;
        private Button btnDel;
    }
}