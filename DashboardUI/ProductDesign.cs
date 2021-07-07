using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DashboardUI
{
    public partial class ProductDesign : UserControl
    {
        private string nullImage = "null.png";
        public ProductDesign()
        {
            InitializeComponent();
        }

        public void setImage(string path)
        {
            try
            {
                picProd.Image = Image.FromFile(path);
                picProd.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {
                picProd.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, @"Data\", nullImage));
                picProd.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void setName(string name)
        {
            lblName.Text = name;
        }

        public void setDesc(string desc)
        {
            lblDescp.Text = desc;
        }

        public void setPrice(double price)
        {
            lblPrice.Text = price.ToString() + " TL";
        }

        public Button getAddButton()
        {
            return btnAddToCart;
        }

        public string getName()
        {
            return lblName.Text.ToLower();
        }
      
    }
}
