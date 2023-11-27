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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            menuStrip1 = new MenuStrip();
            akkToolStripMenuItem = new ToolStripMenuItem();
            departToolStripMenuItem = new ToolStripMenuItem();
            parselToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btnBack = new Button();
            comBox = new ComboBox();
            txtSh = new TextBox();
            btnSh = new Button();
            btnInf = new Button();
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
            menuStrip1.Size = new Size(1080, 28);
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(875, 461);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.AutoSize = true;
            btnBack.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(893, 449);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(175, 43);
            btnBack.TabIndex = 5;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // comBox
            // 
            comBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBox.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            comBox.FormattingEnabled = true;
            comBox.Location = new Point(893, 31);
            comBox.Name = "comBox";
            comBox.Size = new Size(175, 36);
            comBox.TabIndex = 9;
            // 
            // txtSh
            // 
            txtSh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSh.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtSh.Location = new Point(893, 73);
            txtSh.Name = "txtSh";
            txtSh.Size = new Size(175, 35);
            txtSh.TabIndex = 10;
            // 
            // btnSh
            // 
            btnSh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSh.AutoSize = true;
            btnSh.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSh.Location = new Point(900, 123);
            btnSh.Name = "btnSh";
            btnSh.Size = new Size(160, 38);
            btnSh.TabIndex = 12;
            btnSh.Text = "Пошук";
            btnSh.UseVisualStyleBackColor = true;
            // 
            // btnInf
            // 
            btnInf.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInf.AutoSize = true;
            btnInf.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnInf.Location = new Point(900, 405);
            btnInf.Name = "btnInf";
            btnInf.Size = new Size(160, 38);
            btnInf.TabIndex = 14;
            btnInf.Text = "Деталі";
            btnInf.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1080, 504);
            Controls.Add(dataGridView1);
            Controls.Add(btnInf);
            Controls.Add(btnSh);
            Controls.Add(txtSh);
            Controls.Add(comBox);
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
        private ComboBox comBox;
        private TextBox txtSh;
        private Button btnSh;
        private Button btnInf;
    }
}