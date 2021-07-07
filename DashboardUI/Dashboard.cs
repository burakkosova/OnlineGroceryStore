using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Entities;
using Business;
using System.Threading;
using Utilities.Validation;
using Utilities.Results;
using System.Threading.Tasks;

namespace DashboardUI
{
    public partial class Dashboard : Form
    {
        private List<Product> products;
        private Button currentButton;
        private Panel leftBorderBtn;
        public static int count;

        public Dashboard()
        {
            InitializeComponent();
            txtSearch.GotFocus += RemoveText;
            txtSearch.LostFocus += AddText;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(5, 63);
            panelLeft.Controls.Add(leftBorderBtn);

            lblUserName.Text = Login.currentUser.FirstName + " " + Login.currentUser.LastName;
            if (string.IsNullOrEmpty(((Customer)Login.currentUser).ProfilePicture))
            {
                ((Customer)Login.currentUser).ProfilePicture = "default.jpg";
            }
            pbxPicture.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, @"Data\", ((Customer)Login.currentUser).ProfilePicture));

            products = ProductManager.CreateAsSingleton().GetAll();

            foreach (Product prod in products)
            {
                prod.ImagePath = Path.Combine(Environment.CurrentDirectory, @"Data\", prod.FileName);
            }

        }

        public void RemoveText(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "Search something...")
            {
                txtSearch.ForeColor = SystemColors.Control;
                txtSearch.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search something...";
                txtSearch.ForeColor = Color.DarkGray;

            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        Point lastPoint;

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {

                if (currentButton != (Button)btnSender)
                {
                    foreach (Control panel in (btnSender as Button).Controls)
                    {
                        if (panel.GetType() == typeof(Panel))
                        {
                            panel.Visible = true;
                        }
                    }

                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(0, 64, 64);
                    //currentButton.Margin = new Padding(20, 0, 0, 0);
                    if ((btnSender as Button).Name == "btnCart")
                    {
                        //lblChart.Margin = new Padding(20, 0, 0, 0);
                    }
                    leftBorderBtn.BackColor = Color.FromArgb(118, 181, 197);
                    leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelLeft.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(57, 50, 96);
                    //previousBtn.Padding = new Padding(5, 0, 0, 0);
                }
            }
            //lblChart.Margin = new Padding(5, 0, 0, 0);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            Application.DoEvents();
            btnSearch.Visible = true;
            txtSearch.Visible = true;
            GetProductsToPanel();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            btnSearch.Visible = false;
            txtSearch.Visible = false;
            panelMain.Controls.Clear();
            GetShoppingCartItems();
        }

        private void GetShoppingCartItems()
        {
            panelMain.Controls.Clear();
            FlowLayoutPanel flw = new FlowLayoutPanel();
            panelMain.Controls.Add(flw);
            flw.Visible = true;
            flw.BringToFront();
            flw.Dock = DockStyle.Fill;
            flw.AutoScroll = true;

            lblChart.Visible = true;
            count = 0;
            List<ShoppingCart> shoppingCarts = ShoppingCartManager.CreateAsSingleton().GetCustomerCart(Login.currentUser.Id);
            foreach (ShoppingCart sp in shoppingCarts)
            {
                count += sp.Amount;
                ShoppingCartItemDesign shoppingCartItem = new ShoppingCartItemDesign(sp);

                flw.Controls.Add(shoppingCartItem);
                List<Button> buttons = shoppingCartItem.GetButtons();
                foreach (var button in buttons)
                {
                    button.Click += new EventHandler(UpdateLabelChart);
                }
            }
            lblChart.Text = count.ToString();
        }

        private void UpdateLabelChart(object sender, EventArgs e)
        {
            lblChart.Text = count.ToString();
        }

        private void GetProductsToPanel()
        {
            panelMain.Controls.Clear();
            FlowLayoutPanel flw = new FlowLayoutPanel();
            panelMain.Controls.Add(flw);
            flw.Visible = true;
            flw.BringToFront();
            flw.Dock = DockStyle.Fill;
            flw.AutoScroll = true;
            foreach (Product prod in products)
            {
                string str = "Search something...";
                if (prod.Name.ToLower().Contains(txtSearch.Text.ToLower()) || prod.Description.ToLower().Contains(txtSearch.Text.ToLower()) || str.Equals(txtSearch.Text))
                {
                    ProductDesign prodDes = new ProductDesign();
                    prodDes.setName(prod.Name);
                    prodDes.setDesc(prod.Description);
                    prodDes.setImage(prod.ImagePath);
                    prodDes.setPrice(prod.Price);
                    Button addCart = prodDes.getAddButton();
                    addCart.Click += btnAddProdToCart;
                    addCart.TabIndex = prod.Id;
                    flw.Controls.Add(prodDes);
                }
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    txtSearch.ForeColor = SystemColors.Control;
                    txtSearch.Text = "";
                }
            }

        }

        public void btnAddProdToCart(object sender, EventArgs e)
        {
            ShoppingCartManager.CreateAsSingleton().Add(new ShoppingCart
            {
                CustomerId = Login.currentUser.Id,
                Amount = 1,
                Product = new Product { Id = (sender as Button).TabIndex }
            });
            count++;
            lblChart.Text = count.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetProductsToPanel();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            Dispose();
        }

        private void btnEditFirstName_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = false;
            pnlFirstName.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            txtSearch.Visible = false;
            btnSearch.Visible = false;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(panelSettings);
            panelSettings.Visible = true;
            panelSettings.BringToFront();

            Customer customer = (Customer)Login.currentUser;
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = Login.currentUser.LastName;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.PhoneNumber;
            txtAddress.Text = customer.Address;
            if (string.IsNullOrEmpty(customer.ProfilePicture))
            {
                customer.ProfilePicture = "default.jpg";
            }
            pbxProfilePicture.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, @"Data\", customer.ProfilePicture));
        }

        private void btnEditLastName_Click(object sender, EventArgs e)
        {
            txtLastName.ReadOnly = false;
            pnlLastName.Visible = true;
        }

        private void btnEditEmail_Click(object sender, EventArgs e)
        {
            txtEmail.ReadOnly = false;
            pnlEmail.Visible = true;
        }

        private void btnEditPhone_Click(object sender, EventArgs e)
        {
            txtPhone.ReadOnly = false;
            pnlPhone.Visible = true;
        }

        private void btnEditAddress_Click(object sender, EventArgs e)
        {
            txtAddress.ReadOnly = false;
            txtAddress.BorderStyle = BorderStyle.Fixed3D;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            gbxChangePassword.Visible = true;
            btnShowPassword.Visible = false;
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!Validation.ValidatePassword(txtCurrentPassword.Text.Trim()).Success)
            {
                lblInfo.Text = "Please check your current password";
                return;
            }

            IResult result = CustomerManager.CreateAsSingleton().Login(Login.currentUser.Email, txtCurrentPassword.Text.Trim());
            if (!result.Success)
            {
                lblInfo.Text = "The current password you have entered is incorrect";
                return;
            }

            result = Validation.ValidatePassword(txtNewPassword.Text.Trim());
            if (!result.Success)
            {
                lblInfo.Text = result.Message;
                return;
            }

            if (txtNewPassword.Text.Trim().Equals(Login.currentUser.Password))
            {
                lblInfo.Text = "New password must be different from old one";
                return;
            }

            CustomerManager.CreateAsSingleton().UpdatePassword(Login.currentUser.Id, txtNewPassword.Text.Trim());
            lblInfo.Text = "Password changed succesfully";

            await Task.Delay(3000);
            gbxChangePassword.Visible = false;
            btnShowPassword.Visible = true;
            lblInfo.Text = "";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)Login.currentUser;
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.Email = txtEmail.Text;
            customer.PhoneNumber = txtPhone.Text;
            customer.Address = txtAddress.Text;
            IResult result = Validation.ValidateCustomer(customer);
            if (!result.Success)
            {
                lblGeneralInfo.Text = result.Message;
                return;
            }
            CustomerManager.CreateAsSingleton().Update(customer);
            lblGeneralInfo.Text = "Changes saved succesfull ✔";
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbxProfilePicture.Image = new Bitmap(open.FileName);
                pbxPicture.Image = new Bitmap(open.FileName);
                // image file path  
                ((Customer)Login.currentUser).ProfilePicture = Path.GetFileName(open.FileName);

                string destFile = Path.Combine(Path.Combine(Environment.CurrentDirectory, @"Data"), Path.GetFileName(open.FileName));
                File.Copy(open.FileName, destFile, true);
            }
        }
    }
}
