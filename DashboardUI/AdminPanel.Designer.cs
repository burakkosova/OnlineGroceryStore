
namespace DashboardUI
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.panelinformation = new System.Windows.Forms.Panel();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelProductDesc = new System.Windows.Forms.Label();
            this.labelProductPrice = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.btnAcceptChanges = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBrowseNew = new System.Windows.Forms.Button();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.txtNewDesc = new System.Windows.Forms.TextBox();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.panelinformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.panelUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.Location = new System.Drawing.Point(51, 199);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDescription.Location = new System.Drawing.Point(13, 271);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(99, 20);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description :";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPrice.Location = new System.Drawing.Point(58, 235);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(54, 20);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Price :";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblImage.Location = new System.Drawing.Point(47, 307);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(65, 20);
            this.lblImage.TabIndex = 0;
            this.lblImage.Text = "Image :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(114, 196);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 26);
            this.txtName.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(114, 268);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(142, 26);
            this.txtDesc.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(114, 232);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(142, 26);
            this.txtPrice.TabIndex = 1;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(114, 304);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(142, 26);
            this.txtFileName.TabIndex = 3;
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 20;
            this.listBoxProducts.Location = new System.Drawing.Point(279, 76);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(201, 404);
            this.listBoxProducts.TabIndex = 2;
            this.listBoxProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxProducts_SelectedIndexChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(181, 336);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 29);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(114, 387);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 29);
            this.btnAddProduct.TabIndex = 5;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(304, 502);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(75, 29);
            this.btnDeleteProduct.TabIndex = 6;
            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(385, 502);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(75, 29);
            this.btnUpdateProduct.TabIndex = 7;
            this.btnUpdateProduct.Text = "Update";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // panelinformation
            // 
            this.panelinformation.Controls.Add(this.pictureBoxProduct);
            this.panelinformation.Controls.Add(this.label1);
            this.panelinformation.Controls.Add(this.labelProductDesc);
            this.panelinformation.Controls.Add(this.labelProductPrice);
            this.panelinformation.Controls.Add(this.labelProductName);
            this.panelinformation.Location = new System.Drawing.Point(487, 76);
            this.panelinformation.Name = "panelinformation";
            this.panelinformation.Size = new System.Drawing.Size(313, 404);
            this.panelinformation.TabIndex = 4;
            this.panelinformation.Visible = false;
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(125, 47);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(157, 151);
            this.pictureBoxProduct.TabIndex = 1;
            this.pictureBoxProduct.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Informations :";
            // 
            // labelProductDesc
            // 
            this.labelProductDesc.AutoSize = true;
            this.labelProductDesc.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProductDesc.Location = new System.Drawing.Point(21, 228);
            this.labelProductDesc.Name = "labelProductDesc";
            this.labelProductDesc.Size = new System.Drawing.Size(61, 20);
            this.labelProductDesc.TabIndex = 0;
            this.labelProductDesc.Text = "Name :";
            // 
            // labelProductPrice
            // 
            this.labelProductPrice.AutoSize = true;
            this.labelProductPrice.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProductPrice.Location = new System.Drawing.Point(21, 82);
            this.labelProductPrice.Name = "labelProductPrice";
            this.labelProductPrice.Size = new System.Drawing.Size(61, 20);
            this.labelProductPrice.TabIndex = 0;
            this.labelProductPrice.Text = "Name :";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProductName.Location = new System.Drawing.Point(21, 47);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(61, 20);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Name :";
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.btnAcceptChanges);
            this.panelUpdate.Controls.Add(this.btnBack);
            this.panelUpdate.Controls.Add(this.btnBrowseNew);
            this.panelUpdate.Controls.Add(this.txtNewPrice);
            this.panelUpdate.Controls.Add(this.txtNewFileName);
            this.panelUpdate.Controls.Add(this.txtNewDesc);
            this.panelUpdate.Controls.Add(this.txtNewName);
            this.panelUpdate.Controls.Add(this.label2);
            this.panelUpdate.Controls.Add(this.label3);
            this.panelUpdate.Controls.Add(this.label4);
            this.panelUpdate.Controls.Add(this.label5);
            this.panelUpdate.Location = new System.Drawing.Point(17, 12);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(790, 532);
            this.panelUpdate.TabIndex = 5;
            this.panelUpdate.Visible = false;
            // 
            // btnAcceptChanges
            // 
            this.btnAcceptChanges.Location = new System.Drawing.Point(350, 321);
            this.btnAcceptChanges.Name = "btnAcceptChanges";
            this.btnAcceptChanges.Size = new System.Drawing.Size(75, 29);
            this.btnAcceptChanges.TabIndex = 5;
            this.btnAcceptChanges.Text = "Update";
            this.btnAcceptChanges.UseVisualStyleBackColor = true;
            this.btnAcceptChanges.Click += new System.EventHandler(this.btnAcceptChanges_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(34, 24);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 58);
            this.btnBack.TabIndex = 11;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBrowseNew
            // 
            this.btnBrowseNew.Location = new System.Drawing.Point(425, 286);
            this.btnBrowseNew.Name = "btnBrowseNew";
            this.btnBrowseNew.Size = new System.Drawing.Size(75, 29);
            this.btnBrowseNew.TabIndex = 4;
            this.btnBrowseNew.Text = "Browse";
            this.btnBrowseNew.UseVisualStyleBackColor = true;
            this.btnBrowseNew.Click += new System.EventHandler(this.btnBrowseNew_Click);
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Location = new System.Drawing.Point(317, 182);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(207, 26);
            this.txtNewPrice.TabIndex = 1;
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.Location = new System.Drawing.Point(317, 254);
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.Size = new System.Drawing.Size(207, 26);
            this.txtNewFileName.TabIndex = 3;
            // 
            // txtNewDesc
            // 
            this.txtNewDesc.Location = new System.Drawing.Point(317, 218);
            this.txtNewDesc.Name = "txtNewDesc";
            this.txtNewDesc.Size = new System.Drawing.Size(207, 26);
            this.txtNewDesc.TabIndex = 2;
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(317, 146);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(207, 26);
            this.txtNewName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(250, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(261, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(216, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(254, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Name :";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(755, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 58);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdmin.Location = new System.Drawing.Point(47, 22);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(0, 20);
            this.lblAdmin.TabIndex = 0;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(819, 591);
            this.Controls.Add(this.panelUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelinformation);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.listBoxProducts);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AdminPanel_MouseMove);
            this.panelinformation.ResumeLayout(false);
            this.panelinformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Panel panelinformation;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProductDesc;
        private System.Windows.Forms.Label labelProductPrice;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.Button btnAcceptChanges;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnBrowseNew;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.TextBox txtNewDesc;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAdmin;
    }
}