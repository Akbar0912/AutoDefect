namespace AutoDefect.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnLogOut = new Button();
            btnRePrint = new Button();
            btnHome = new Button();
            btnSetting = new Button();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Teal;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 561F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 5, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1276, 89);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(718, 5);
            label2.Name = "label2";
            label2.Size = new Size(555, 84);
            label2.TabIndex = 2;
            label2.Text = "Laundry System Business Unit";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Helvetica", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 5);
            label1.Margin = new Padding(3, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(712, 84);
            label1.TabIndex = 1;
            label1.Text = "PRODUCT DEFECT RECORD";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Teal;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(btnLogOut, 0, 6);
            tableLayoutPanel4.Controls.Add(btnRePrint, 0, 2);
            tableLayoutPanel4.Controls.Add(btnHome, 0, 0);
            tableLayoutPanel4.Controls.Add(btnSetting, 0, 4);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Margin = new Padding(3, 0, 3, 5);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 8;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 2.08333325F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 27.34375F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 2.60416675F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 28.385416F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 39.48052F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(103, 584);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.Red;
            btnLogOut.Dock = DockStyle.Fill;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Helvetica", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Image = (Image)resources.GetObject("btnLogOut.Image");
            btnLogOut.Location = new Point(3, 475);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(97, 84);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "Log Out";
            btnLogOut.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogOut.UseVisualStyleBackColor = false;
            // 
            // btnRePrint
            // 
            btnRePrint.Dock = DockStyle.Fill;
            btnRePrint.FlatAppearance.BorderSize = 0;
            btnRePrint.FlatStyle = FlatStyle.Flat;
            btnRePrint.Font = new Font("Helvetica", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRePrint.ForeColor = Color.White;
            btnRePrint.Image = (Image)resources.GetObject("btnRePrint.Image");
            btnRePrint.Location = new Point(3, 99);
            btnRePrint.Name = "btnRePrint";
            btnRePrint.Size = new Size(97, 99);
            btnRePrint.TabIndex = 3;
            btnRePrint.Text = "Record Defect";
            btnRePrint.TextAlign = ContentAlignment.BottomCenter;
            btnRePrint.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRePrint.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Fill;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Helvetica", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(103, 88);
            btnHome.TabIndex = 2;
            btnHome.Text = "\r\nPrint Defect";
            btnHome.TextAlign = ContentAlignment.BottomCenter;
            btnHome.TextImageRelation = TextImageRelation.ImageAboveText;
            btnHome.UseVisualStyleBackColor = true;
            // 
            // btnSetting
            // 
            btnSetting.Dock = DockStyle.Fill;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("Helvetica", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSetting.ForeColor = Color.White;
            btnSetting.Image = (Image)resources.GetObject("btnSetting.Image");
            btnSetting.Location = new Point(3, 214);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(97, 103);
            btnSetting.TabIndex = 1;
            btnSetting.Text = "\r\nSetting";
            btnSetting.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSetting.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 89);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(224, 235, 245);
            splitContainer1.Size = new Size(1276, 584);
            splitContainer1.SplitterDistance = 103;
            splitContainer1.TabIndex = 16;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 673);
            Controls.Add(splitContainer1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnLogOut;
        private Button btnRePrint;
        private Button btnHome;
        private Button btnSetting;
        private SplitContainer splitContainer1;
    }
}