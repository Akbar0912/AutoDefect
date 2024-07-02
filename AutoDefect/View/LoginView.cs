using AutoDefect.View;

namespace AutoDefect
{
    public partial class LoginView : Form, ILoginView
    {
        public bool isClickedOnce = true;

        public LoginView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public string Nik
        {
            get { return textBoxNik.Text; }
            set { textBoxNik.Text = value; }
        }
        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }

        public bool IsLoggedIn { get; private set; }

        public event EventHandler Login;

        private void AssociateAndRaiseViewEvents()
        {
            btnLogin.Click += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(Nik))
                {
                    Login?.Invoke(this, EventArgs.Empty);
                }
            };

            btnExit.Click += delegate
            {
                Application.Exit();
            };

            hiddenPass.Click += delegate
            {
                if (isClickedOnce)
                {
                    hiddenPass.Image = Properties.Resources.show__1_;
                    textBoxPassword.PasswordChar = '\0';
                    isClickedOnce = false;
                }
                else
                {
                    hiddenPass.Image = Properties.Resources.eye;
                    textBoxPassword.PasswordChar = '*';
                    isClickedOnce = true;
                }
            };
        }

        public void CloseView()
        {
            this.Hide();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message,"PEMBERITAHUAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBoxNik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(Nik))
            {
                Login?.Invoke(this, EventArgs.Empty);
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(Password))
            {
                Login?.Invoke(this, EventArgs.Empty);
            }
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            textBoxNik.Focus();
        }
    }
}
