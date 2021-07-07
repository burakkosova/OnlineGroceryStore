using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DashboardUI
{
    public partial class AdminPanel : Form
    {
        private List<Product> products;

        string sourcePath = "";
        string targetPath = "";
        string destFile = "";

        public AdminPanel()
        {
            InitializeComponent();

            lblAdmin.Text = "Welcome Back " + Login.currentUser.FirstName + " " + Login.currentUser.LastName;

            products = ProductManager.CreateAsSingleton().GetAll();

            foreach (Product prod in products)
            {
                prod.ImagePath = Path.Combine(Environment.CurrentDirectory, @"Data\", prod.FileName);
                listBoxProducts.Items.Add(prod.Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        Point lastPoint;
        private void AdminPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void AdminPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "" && txtPrice.Text != "" && txtDesc.Text != "")
            {
                Product product = new Product
                {
                    Name = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    Description = txtDesc.Text,
                    FileName = txtFileName.Text
                };

                try
                {
                    if (!string.IsNullOrEmpty(txtFileName.Text))
                    {
                        Directory.CreateDirectory(targetPath);
                        File.Copy(sourcePath, destFile, true);
                    }

                    product.ImagePath = Path.Combine(Environment.CurrentDirectory, @"Data\", product.FileName);
                    listBoxProducts.Items.Add(product.Name);
                    ProductManager.CreateAsSingleton().AddProduct(product);
                    //products = ProductManager.CreateAsSingleton().GetAll();
                    products.Add(product);
                }
                catch (Exception)
                {
                    MessageBox.Show("This image is used for another product! Please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                clearText();
            }


            else
            {
                MessageBox.Show("There are some blanks that are need to be fillen. ");
            }
        }

        private void clearText()
        {
            txtFileName.Clear();
            txtName.Clear();
            txtDesc.Clear();
            txtPrice.Clear();
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelinformation.Visible = true;
            try
            {
                Product prod = products.SingleOrDefault(c => c.Name == listBoxProducts.GetItemText(listBoxProducts.SelectedItem));
                //prod.ImagePath = Path.Combine(Environment.CurrentDirectory, @"Data\", prod.FileName);
                showDescripton(prod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void showDescripton(Product prod)
        {
            if (prod != null)
            {
                labelProductName.Text = prod.Name;
                labelProductPrice.Text = Convert.ToString(prod.Price) + " TL";
                labelProductDesc.Text = prod.Description;
                pictureBoxProduct.Image = Image.FromFile(prod.ImagePath);
                pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();


            if (dr == DialogResult.OK)
            {
                txtFileName.Text = Path.GetFileName(ofd.FileName);
                sourcePath = ofd.FileName;
                targetPath = Path.Combine(Environment.CurrentDirectory, @"Data");
                destFile = Path.Combine(targetPath, Path.GetFileName(ofd.FileName));
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedItems.Count > 0)
            {
                Product prod = products.SingleOrDefault(c => c.Name == listBoxProducts.GetItemText(listBoxProducts.SelectedItem));
                if (prod != null)
                {
                    products.Remove(prod);
                    ProductManager.CreateAsSingleton().DeleteProduct(prod.Id);
                    listBoxProducts.Items.Remove(listBoxProducts.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("You need to select product that is wanted to remove.");
            }

            panelinformation.Visible = false;

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            Product prod = products.SingleOrDefault(c => c.Name == listBoxProducts.GetItemText(listBoxProducts.SelectedItem));

            if (prod == null)
            {
                MessageBox.Show("Please select a product to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panelUpdate.Visible = true;
            txtNewName.Text = prod.Name;
            txtNewPrice.Text = Convert.ToString(prod.Price);
            txtNewDesc.Text = prod.Description;
            txtNewFileName.Text = prod.FileName;
        }

        private void btnAcceptChanges_Click(object sender, EventArgs e)
        {
            Product prod = products.SingleOrDefault(c => c.Name == listBoxProducts.GetItemText(listBoxProducts.SelectedItem));

            if (txtNewName.Text != "" && txtNewPrice.Text != "" && txtNewDesc.Text != "" && txtNewFileName.Text != "")
            {

                try
                {
                    if (txtNewFileName.Text != prod.FileName)
                    {
                        Directory.CreateDirectory(targetPath);
                        File.Copy(sourcePath, destFile, true);
                        prod.FileName = txtNewFileName.Text;
                        prod.ImagePath = Path.Combine(Environment.CurrentDirectory, @"Data\", prod.FileName);
                    }
                    prod.Name = txtNewName.Text;
                    prod.Price = double.Parse(txtNewPrice.Text);
                    prod.Description = txtNewDesc.Text;
                    listBoxProducts.Items[listBoxProducts.SelectedIndex] = prod.Name;

                    ProductManager.CreateAsSingleton().UpdateProduct(prod);

                    txtNewName.Text = "";
                    txtNewPrice.Text = "";
                    txtNewDesc.Text = "";
                    txtNewFileName.Text = "";

                    panelUpdate.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This image is used for another product! Please choose another one.");
                }

            }


            else
            {
                MessageBox.Show("There are some blanks that are need to be fillen. ");
            }

        }

        private void btnBrowseNew_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtNewFileName.Text = Path.GetFileName(ofd.FileName);
                sourcePath = ofd.FileName;
                targetPath = Path.Combine(Environment.CurrentDirectory, @"Data");
                destFile = Path.Combine(targetPath, Path.GetFileName(ofd.FileName));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = false;
        }
    }
}
