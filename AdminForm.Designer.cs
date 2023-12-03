namespace TrackEZ
{
    partial class AdminForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            menuStrip1 = new MenuStrip();
            akkToolStripMenuItem = new ToolStripMenuItem();
            departToolStripMenuItem = new ToolStripMenuItem();
            parselToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btnBack = new Button();
            comBoxSh = new ComboBox();
            txtSh = new TextBox();
            btnSh = new Button();
            btnInf = new Button();
            btnAdd = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { akkToolStripMenuItem, departToolStripMenuItem, parselToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1253, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // akkToolStripMenuItem
            // 
            akkToolStripMenuItem.Name = "akkToolStripMenuItem";
            akkToolStripMenuItem.Size = new Size(79, 24);
            akkToolStripMenuItem.Text = "Акаунти";
            akkToolStripMenuItem.Click += akkToolStripMenuItem_Click;
            // 
            // departToolStripMenuItem
            // 
            departToolStripMenuItem.Name = "departToolStripMenuItem";
            departToolStripMenuItem.Size = new Size(98, 24);
            departToolStripMenuItem.Text = "Відділення";
            departToolStripMenuItem.Click += departToolStripMenuItem_Click;
            // 
            // parselToolStripMenuItem
            // 
            parselToolStripMenuItem.Name = "parselToolStripMenuItem";
            parselToolStripMenuItem.Size = new Size(83, 24);
            parselToolStripMenuItem.Text = "Посилки";
            parselToolStripMenuItem.Click += parselToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Menu;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(1030, 461);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.AutoSize = true;
            btnBack.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(1064, 457);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 35);
            btnBack.TabIndex = 5;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // comBoxSh
            // 
            comBoxSh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxSh.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxSh.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comBoxSh.FormattingEnabled = true;
            comBoxSh.Location = new Point(1048, 31);
            comBoxSh.Name = "comBoxSh";
            comBoxSh.Size = new Size(193, 33);
            comBoxSh.TabIndex = 9;
            // 
            // txtSh
            // 
            txtSh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSh.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSh.Location = new Point(1048, 73);
            txtSh.Name = "txtSh";
            txtSh.Size = new Size(193, 32);
            txtSh.TabIndex = 10;
            // 
            // btnSh
            // 
            btnSh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSh.AutoSize = true;
            btnSh.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSh.Location = new Point(1064, 123);
            btnSh.Name = "btnSh";
            btnSh.Size = new Size(160, 38);
            btnSh.TabIndex = 12;
            btnSh.Text = "Пошук";
            btnSh.UseVisualStyleBackColor = true;
            btnSh.Click += btnSh_Click;
            // 
            // btnInf
            // 
            btnInf.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInf.AutoSize = true;
            btnInf.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnInf.Location = new Point(1073, 409);
            btnInf.Name = "btnInf";
            btnInf.Size = new Size(143, 35);
            btnInf.TabIndex = 14;
            btnInf.Text = "Деталі";
            btnInf.UseVisualStyleBackColor = true;
            btnInf.Click += btnInf_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(1088, 361);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(113, 35);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1253, 504);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(btnInf);
            Controls.Add(btnSh);
            Controls.Add(txtSh);
            Controls.Add(comBoxSh);
            Controls.Add(btnBack);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TrackEZ";
            FormClosing += AdminForm_FormClosing;
            Load += AdminForm_Load;
            KeyDown += AdminForm_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem akkToolStripMenuItem;
        private ToolStripMenuItem parselToolStripMenuItem;
        private DataGridView dataGridView1;
        private ToolStripMenuItem departToolStripMenuItem;
        private Button btnBack;
        private ComboBox comBoxSh;
        private TextBox txtSh;
        private Button btnSh;
        private Button btnInf;
        private Button btnAdd;
    }
}