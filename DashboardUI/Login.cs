using Business;
using DataAccess.Concrete;
using Entities;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Results;
using Utilities.Validation;

namespace DashboardUI
{
    public partial class Login : Form
    {
        public static User currentUser;
        private IUserManager _userManager;
        public Login()
        {
            InitializeComponent();
            txtEmail.GotFocus += RemoveText;
            txtEmail.LostFocus += AddText;
            txtPassword.GotFocus += RemoveText;
            txtPassword.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "Email")
            {
                txtEmail.ForeColor = SystemColors.Control;
                txtEmail.Text = "";
            }
            if ((sender as TextBox).Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = SystemColors.Control;
                txtPassword.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.DarkGray;

            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;

                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DarkGray;
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _userManager = CustomerManager.CreateAsSingleton();

            IResult validationResult = Validation.ValidateLogin(txtEmail.Text.Trim(), txtPassword.Text.Trim());
            if (!validationResult.Success)
            {
                lblInfo.Text = validationResult.Message;
                return;
            }

            IDataResult<User> result = _userManager.Login(txtEmail.Text.Trim(), txtPassword.Text.Trim());
            if (!result.Success)
            {
                lblInfo.Text = result.Message;
                return;
            }

            currentUser = result.Data;

            Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
            Dispose();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            Register register = new Register();
            register.ShowDialog();
            Dispose();
        }
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            _userManager = new AdminManager(new AdminDal());
            IResult validationResult = Validation.ValidateLogin(txtEmail.Text.Trim(), txtPassword.Text.Trim());
            if (!validationResult.Success)
            {
                lblInfo.Text = validationResult.Message;
                return;
            }

            IDataResult<User> result = _userManager.Login(txtEmail.Text.Trim(), txtPassword.Text.Trim());
            if (!result.Success)
            {
                lblInfo.Text = result.Message;
                return;
            }

            currentUser = result.Data;

            // open admin panel
            Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.ShowDialog();
            Dispose();
        }
    }
}
