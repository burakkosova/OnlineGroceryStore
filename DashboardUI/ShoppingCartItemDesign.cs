using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DashboardUI
{
    public partial class ShoppingCartItemDesign : UserControl
    {
        private ShoppingCart _shoppingCart;
        int firstPlusAmount;
        int firstMinusAmount;

        public ShoppingCartItemDesign(ShoppingCart shoppingCart)
        {
            InitializeComponent();
            _shoppingCart = shoppingCart;
            SetLabels();
            firstPlusAmount = _shoppingCart.Amount;
            firstMinusAmount = _shoppingCart.Amount;
        }

        private void SetLabels()
        {
            lblProductName.Text = _shoppingCart.Product.Name;
            lblProductPrice.Text = _shoppingCart.Product.Price.ToString() + " ₺";
            UpdateAmount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dashboard.count -= _shoppingCart.Amount;

            Parent.Controls.Remove(this);
            ShoppingCartManager.CreateAsSingleton().DeleteProduct(_shoppingCart);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Dashboard.count++;
            _shoppingCart.Amount++;
            UpdateAmount();
            if (_shoppingCart.Amount == firstPlusAmount)
            {
                btnAccept.Visible = false;
                return;
            }
            btnAccept.Visible = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Dashboard.count--;
            _shoppingCart.Amount--;
            if (_shoppingCart.Amount == 0)
            {
                btnDelete.PerformClick();
                return;
            }
            UpdateAmount();
            if (_shoppingCart.Amount == firstMinusAmount)
            {
                btnAccept.Visible = false;
                return;
            }
            btnAccept.Visible = true;
        }

        private void UpdateAmount()
        {
            lblAmount.Text = _shoppingCart.Amount.ToString();
            lblTotalPrice.Text = (_shoppingCart.Product.Price * _shoppingCart.Amount).ToString() + " ₺";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ShoppingCartManager.CreateAsSingleton().UpdateAmount(_shoppingCart);
            btnAccept.Visible = false;
            firstPlusAmount = _shoppingCart.Amount;
            firstMinusAmount = _shoppingCart.Amount;
        }

        public List<Button> GetButtons()
        {
            List<Button> buttons = new List<Button>(){ btnAccept, btnDelete };
            return buttons;
        }
    }
}
