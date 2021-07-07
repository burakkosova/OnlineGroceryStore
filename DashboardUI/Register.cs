using Business;
using Entities;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Results;
using Utilities.Validation;

namespace DashboardUI
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            txtEmail.GotFocus += RemoveText;
            txtEmail.LostFocus += AddText;

            txtPassword.GotFocus += RemoveText;
            txtPassword.LostFocus += AddText;

            txtAddress.GotFocus += RemoveText;
            txtAddress.LostFocus += AddText;

            txtPhone.GotFocus += RemoveText;
            txtPhone.LostFocus += AddText;

            txtConfirmPass.GotFocus += RemoveText;
            txtConfirmPass.LostFocus += AddText;

            txtSurname.GotFocus += RemoveText;
            txtSurname.LostFocus += AddText;

            txtName.GotFocus += RemoveText;
            txtName.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "Email")
            {
                txtEmail.ForeColor = SystemColors.Control;
                txtEmail.Text = "";
            }

            if ((sender as TextBox).Text == "Name")
            {
                txtName.ForeColor = SystemColors.Control;
                txtName.Text = "";
            }

            if ((sender as TextBox).Text == "Surname")
            {
                txtSurname.ForeColor = SystemColors.Control;
                txtSurname.Text = "";
            }

            if ((sender as TextBox).Text == "Address")
            {
                txtAddress.ForeColor = SystemColors.Control;
                txtAddress.Text = "";
            }

            if ((sender as TextBox).Text == "Phone Number")
            {
                txtPhone.ForeColor = SystemColors.Control;
                txtPhone.Text = "";
            }

            if ((sender as TextBox).Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = SystemColors.Control;
                txtPassword.Text = "";
            }
            if ((sender as TextBox).Text == "Confirm Password")
            {
                txtConfirmPass.UseSystemPasswordChar = true;
                txtConfirmPass.ForeColor = SystemColors.Control;
                txtConfirmPass.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.DarkGray;

            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Name";
                txtName.ForeColor = Color.DarkGray;

            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.Text = "Phone Number";
                txtPhone.ForeColor = Color.DarkGray;

            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.Text = "Address";
                txtAddress.ForeColor = Color.DarkGray;

            }
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.Text = "Surname";
                txtSurname.ForeColor = Color.DarkGray;

            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;

                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DarkGray;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                txtConfirmPass.UseSystemPasswordChar = false;

                txtConfirmPass.Text = "Confirm Password";
                txtConfirmPass.ForeColor = Color.DarkGray;

            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!txtPassword.Text.Trim().Equals(txtConfirmPass.Text.Trim()))
            {
                lblInfo.Text = "Passwords doesn't match";
                return;
            }

            Customer customer = new Customer
            {
                FirstName = txtName.Text.Trim(),
                LastName = txtSurname.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            IResult validationResult = Validation.ValidateCustomer(customer);
            if (!validationResult.Success)
            {
                lblInfo.Text = validationResult.Message;
                return;
            }

            IResult result = CustomerManager.CreateAsSingleton().Register(customer);
            if (!result.Success)
            {
                lblInfo.Text = result.Message;
                return;
            }

            lblInfo.Text = "Registered Successfully";
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Hide();
            Login form = new Login();
            form.ShowDialog();
            Dispose();
        }
    }
}
