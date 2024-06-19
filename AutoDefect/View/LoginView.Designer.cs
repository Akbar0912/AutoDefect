namespace AutoDefect
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            hiddenPass = new PictureBox();
            textBoxNik = new TextBox();
            panel2 = new Panel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            textBoxPassword = new TextBox();
            pictureBox3 = new PictureBox();
            rdPanel1 = new Component.RdPanel();
            btnExit = new Component.RdButton();
            btnLogin = new Component.RdButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hiddenPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            rdPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1269, 677);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Helvetica", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(144, 96);
            label2.Name = "label2";
            label2.Size = new Size(529, 43);
            label2.TabIndex = 14;
            label2.Text = "Laundry System Business Unit";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Helvetica", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(86, 39);
            label1.Name = "label1";
            label1.Size = new Size(682, 57);
            label1.TabIndex = 12;
            label1.Text = "PRODUCT DEFECT RECORD";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hiddenPass
            // 
            hiddenPass.Image = Properties.Resources.show;
            hiddenPass.Location = new Point(566, 255);
            hiddenPass.Name = "hiddenPass";
            hiddenPass.Size = new Size(35, 31);
            hiddenPass.SizeMode = PictureBoxSizeMode.Zoom;
            hiddenPass.TabIndex = 20;
            hiddenPass.TabStop = false;
            // 
            // textBoxNik
            // 
            textBoxNik.Anchor = AnchorStyles.None;
            textBoxNik.BackColor = SystemColors.Control;
            textBoxNik.BorderStyle = BorderStyle.None;
            textBoxNik.Font = new Font("Arial", 15.75F);
            textBoxNik.Location = new Point(254, 185);
            textBoxNik.Name = "textBoxNik";
            textBoxNik.PlaceholderText = "NIK";
            textBoxNik.Size = new Size(347, 25);
            textBoxNik.TabIndex = 15;
            textBoxNik.KeyDown += textBoxNik_KeyDown;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(254, 293);
            panel2.Name = "panel2";
            panel2.Size = new Size(347, 3);
            panel2.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(254, 217);
            panel1.Name = "panel1";
            panel1.Size = new Size(347, 3);
            panel1.TabIndex = 18;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(208, 181);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.BackColor = SystemColors.Control;
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Arial", 15.75F);
            textBoxPassword.Location = new Point(254, 261);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(347, 25);
            textBoxPassword.TabIndex = 16;
            textBoxPassword.KeyDown += textBoxPassword_KeyDown;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(208, 259);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(28, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // rdPanel1
            // 
            rdPanel1.Anchor = AnchorStyles.None;
            rdPanel1.BorderColor = Color.Black;
            rdPanel1.BorderSize = 1;
            rdPanel1.Controls.Add(btnExit);
            rdPanel1.Controls.Add(btnLogin);
            rdPanel1.Controls.Add(hiddenPass);
            rdPanel1.Controls.Add(label2);
            rdPanel1.Controls.Add(textBoxNik);
            rdPanel1.Controls.Add(panel2);
            rdPanel1.Controls.Add(label1);
            rdPanel1.Controls.Add(panel1);
            rdPanel1.Controls.Add(pictureBox3);
            rdPanel1.Controls.Add(pictureBox2);
            rdPanel1.Controls.Add(textBoxPassword);
            rdPanel1.CornerRadius = 15;
            rdPanel1.Location = new Point(215, 120);
            rdPanel1.Name = "rdPanel1";
            rdPanel1.Size = new Size(845, 436);
            rdPanel1.TabIndex = 21;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.BackgroundColor = Color.Crimson;
            btnExit.BorderColor = Color.PaleVioletRed;
            btnExit.BorderRadius = 8;
            btnExit.BorderSize = 0;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Helvetica Rounded", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(482, 362);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 40);
            btnExit.TabIndex = 21;
            btnExit.Text = "Exit";
            btnExit.TextColor = Color.White;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkOliveGreen;
            btnLogin.BackgroundColor = Color.DarkOliveGreen;
            btnLogin.BorderColor = Color.PaleVioletRed;
            btnLogin.BorderRadius = 8;
            btnLogin.BorderSize = 0;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Helvetica Rounded", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(191, 362);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 40);
            btnLogin.TabIndex = 21;
            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.White;
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 677);
            Controls.Add(rdPanel1);
            Controls.Add(pictureBox1);
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += LoginView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)hiddenPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            rdPanel1.ResumeLayout(false);
            rdPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private PictureBox hiddenPass;
        private TextBox textBoxNik;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox2;
        private TextBox textBoxPassword;
        private PictureBox pictureBox3;
        private Component.RdPanel rdPanel1;
        private Component.RdButton btnExit;
        private Component.RdButton btnLogin;
    }
}
