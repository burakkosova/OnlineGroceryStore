
namespace DashboardUI
{
    partial class ProductDesign
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picProd = new System.Windows.Forms.PictureBox();
            this.lblDescp = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblName.Location = new System.Drawing.Point(3, 141);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(171, 29);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picProd
            // 
            this.picProd.Location = new System.Drawing.Point(58, 20);
            this.picProd.Name = "picProd";
            this.picProd.Size = new System.Drawing.Size(65, 88);
            this.picProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProd.TabIndex = 1;
            this.picProd.TabStop = false;
            // 
            // lblDescp
            // 
            this.lblDescp.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDescp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDescp.Location = new System.Drawing.Point(3, 181);
            this.lblDescp.Name = "lblDescp";
            this.lblDescp.Size = new System.Drawing.Size(171, 29);
            this.lblDescp.TabIndex = 2;
            this.lblDescp.Text = "Description";
            this.lblDescp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPrice.Location = new System.Drawing.Point(3, 219);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(171, 29);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddToCart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddToCart.Location = new System.Drawing.Point(3, 278);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(171, 34);
            this.btnAddToCart.TabIndex = 4;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // ProductDesign
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescp);
            this.Controls.Add(this.picProd);
            this.Controls.Add(this.lblName);
            this.Name = "ProductDesign";
            this.Size = new System.Drawing.Size(174, 328);
            ((System.ComponentModel.ISupportInitialize)(this.picProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.PictureBox picProd;
        private System.Windows.Forms.Label lblDescp;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnAddToCart;
    }
}
