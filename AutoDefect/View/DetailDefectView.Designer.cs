namespace AutoDefect.View
{
    partial class DetailDefectView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailDefectView));
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textSerial = new Label();
            textModelNumber = new Label();
            textDefect = new Label();
            TextInspector = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label1 = new Label();
            textLocation = new Label();
            label7 = new Label();
            btnPrint = new Component.RdButton();
            btnCancle = new Component.RdButton();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.10101F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.28282833F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.742424F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(textSerial, 2, 0);
            tableLayoutPanel1.Controls.Add(textModelNumber, 2, 1);
            tableLayoutPanel1.Controls.Add(textDefect, 2, 2);
            tableLayoutPanel1.Controls.Add(TextInspector, 2, 3);
            tableLayoutPanel1.Controls.Add(label8, 1, 1);
            tableLayoutPanel1.Controls.Add(label9, 1, 2);
            tableLayoutPanel1.Controls.Add(label10, 1, 3);
            tableLayoutPanel1.Location = new Point(88, 181);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(834, 243);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 11);
            label2.Margin = new Padding(3, 8, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(260, 42);
            label2.TabIndex = 0;
            label2.Text = "Serial Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(297, 9);
            label3.Margin = new Padding(3, 6, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(20, 42);
            label3.TabIndex = 0;
            label3.Text = ":";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 71);
            label4.Margin = new Padding(3, 8, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(265, 42);
            label4.TabIndex = 0;
            label4.Text = "Model Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 131);
            label5.Margin = new Padding(3, 8, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(232, 42);
            label5.TabIndex = 0;
            label5.Text = "Defect Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 191);
            label6.Margin = new Padding(3, 8, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(177, 42);
            label6.TabIndex = 0;
            label6.Text = "Inspector";
            // 
            // textSerial
            // 
            textSerial.AutoSize = true;
            textSerial.Dock = DockStyle.Fill;
            textSerial.Font = new Font("Helvetica", 21.75F);
            textSerial.Location = new Point(326, 16);
            textSerial.Margin = new Padding(3, 13, 3, 0);
            textSerial.Name = "textSerial";
            textSerial.Size = new Size(502, 44);
            textSerial.TabIndex = 0;
            textSerial.Text = "Serial";
            // 
            // textModelNumber
            // 
            textModelNumber.AutoSize = true;
            textModelNumber.Dock = DockStyle.Fill;
            textModelNumber.Font = new Font("Helvetica", 21.75F);
            textModelNumber.Location = new Point(326, 76);
            textModelNumber.Margin = new Padding(3, 13, 3, 0);
            textModelNumber.Name = "textModelNumber";
            textModelNumber.Size = new Size(502, 44);
            textModelNumber.TabIndex = 0;
            textModelNumber.Text = "Model Number";
            // 
            // textDefect
            // 
            textDefect.AutoSize = true;
            textDefect.Dock = DockStyle.Fill;
            textDefect.Font = new Font("Helvetica", 21.75F);
            textDefect.Location = new Point(326, 136);
            textDefect.Margin = new Padding(3, 13, 3, 0);
            textDefect.Name = "textDefect";
            textDefect.Size = new Size(502, 44);
            textDefect.TabIndex = 0;
            textDefect.Text = "Defect";
            // 
            // TextInspector
            // 
            TextInspector.AutoSize = true;
            TextInspector.Dock = DockStyle.Fill;
            TextInspector.Font = new Font("Helvetica", 21.75F);
            TextInspector.Location = new Point(326, 196);
            TextInspector.Margin = new Padding(3, 13, 3, 0);
            TextInspector.Name = "TextInspector";
            TextInspector.Size = new Size(502, 44);
            TextInspector.TabIndex = 0;
            TextInspector.Text = "Inspector";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(297, 69);
            label8.Margin = new Padding(3, 6, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(20, 42);
            label8.TabIndex = 0;
            label8.Text = ":";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(297, 129);
            label9.Margin = new Padding(3, 6, 3, 0);
            label9.Name = "label9";
            label9.Size = new Size(20, 42);
            label9.TabIndex = 0;
            label9.Text = ":";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Helvetica", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(297, 189);
            label10.Margin = new Padding(3, 6, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(20, 42);
            label10.TabIndex = 0;
            label10.Text = ":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Helvetica", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(303, 71);
            label1.Name = "label1";
            label1.Size = new Size(422, 76);
            label1.TabIndex = 1;
            label1.Text = "Detail Defect";
            // 
            // textLocation
            // 
            textLocation.AutoSize = true;
            textLocation.Location = new Point(815, 474);
            textLocation.Name = "textLocation";
            textLocation.Size = new Size(13, 15);
            textLocation.TabIndex = 2;
            textLocation.Text = "0";
            textLocation.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Helvetica", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(243, 455);
            label7.Name = "label7";
            label7.Size = new Size(543, 38);
            label7.TabIndex = 1;
            label7.Text = "Apakah Data Defect Sudah Benar?";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(77, 134, 156);
            btnPrint.BackgroundColor = Color.FromArgb(77, 134, 156);
            btnPrint.BorderColor = Color.PaleVioletRed;
            btnPrint.BorderRadius = 8;
            btnPrint.BorderSize = 0;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Helvetica", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.Location = new Point(256, 543);
            btnPrint.Name = "btnPrint";
            btnPrint.Padding = new Padding(25, 0, 0, 0);
            btnPrint.Size = new Size(165, 50);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "Ok";
            btnPrint.TextColor = Color.White;
            btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnCancle
            // 
            btnCancle.BackColor = Color.Red;
            btnCancle.BackgroundColor = Color.Red;
            btnCancle.BorderColor = Color.PaleVioletRed;
            btnCancle.BorderRadius = 8;
            btnCancle.BorderSize = 0;
            btnCancle.FlatAppearance.BorderSize = 0;
            btnCancle.FlatStyle = FlatStyle.Flat;
            btnCancle.Font = new Font("Helvetica", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancle.ForeColor = Color.White;
            btnCancle.Image = (Image)resources.GetObject("btnCancle.Image");
            btnCancle.Location = new Point(593, 543);
            btnCancle.Name = "btnCancle";
            btnCancle.Padding = new Padding(20, 0, 0, 0);
            btnCancle.Size = new Size(165, 50);
            btnCancle.TabIndex = 3;
            btnCancle.Text = "Cancel";
            btnCancle.TextColor = Color.White;
            btnCancle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancle.UseVisualStyleBackColor = false;
            // 
            // DetailDefectView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 646);
            Controls.Add(btnCancle);
            Controls.Add(btnPrint);
            Controls.Add(textLocation);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DetailDefectView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetailDefectView";
            Load += DetailDefectView_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label textSerial;
        private Label textModelNumber;
        private Label textDefect;
        private Label TextInspector;
        private Label textLocation;
        private Label label7;
        private Component.RdButton btnPrint;
        private Component.RdButton btnCancle;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}