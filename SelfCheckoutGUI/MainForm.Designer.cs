namespace SelfCheckoutApp.GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnEditCart = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.lstCart = new System.Windows.Forms.ListBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(12, 12);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(100, 30);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnEditCart
            // 
            this.btnEditCart.Location = new System.Drawing.Point(12, 48);
            this.btnEditCart.Name = "btnEditCart";
            this.btnEditCart.Size = new System.Drawing.Size(100, 30);
            this.btnEditCart.TabIndex = 1;
            this.btnEditCart.Text = "Edit Cart";
            this.btnEditCart.UseVisualStyleBackColor = true;
            this.btnEditCart.Click += new System.EventHandler(this.btnEditCart_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(12, 84);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(100, 30);
            this.btnCheckout.TabIndex = 2;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lstProducts
            // 
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 15;
            this.lstProducts.Location = new System.Drawing.Point(118, 12);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(200, 109);
            this.lstProducts.TabIndex = 3;
            // 
            // lstCart
            // 
            this.lstCart.FormattingEnabled = true;
            this.lstCart.ItemHeight = 15;
            this.lstCart.Location = new System.Drawing.Point(12, 120);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(306, 109);
            this.lstCart.TabIndex = 4;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 240);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(306, 23);
            this.lblTotalPrice.TabIndex = 5;
            this.lblTotalPrice.Text = "Łączna wartość: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 270);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lstCart);
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnEditCart);
            this.Controls.Add(this.btnAddProduct);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnEditCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.Label lblTotalPrice;
    }
}
