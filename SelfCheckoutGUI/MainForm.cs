using System;
using System.Windows.Forms;

namespace SelfCheckoutApp.GUI
{
    public partial class MainForm : Form
    {
        private ShoppingCart cart;
        private Database db;

        public MainForm()
        {
            InitializeComponent();
            cart = new ShoppingCart();
            db = new Database();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = db.GetProducts();
            lstProducts.Items.Clear();
            foreach (var product in products)
            {
                lstProducts.Items.Add($"{product.Name} - {product.Price:C}");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItem != null)
            {
                var selectedProduct = lstProducts.SelectedItem.ToString();
                var productName = selectedProduct.Split('-')[0].Trim();
                var product = db.GetProducts().Find(p => p.Name == productName);

                if (product != null)
                {
                    cart.AddProduct(product, 1);
                    MessageBox.Show($"{product.Name} został dodany do koszyka.");
                    DisplayCart();
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać produkt do dodania.");
            }
        }

        private void btnEditCart_Click(object sender, EventArgs e)
        {
            var editCartForm = new EditCartForm(cart);
            editCartForm.ShowDialog();
            DisplayCart();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var paymentForm = new PaymentForm(cart);
            paymentForm.ShowDialog();
            DisplayCart();
        }

        private void DisplayCart()
        {
            lstCart.Items.Clear();
            var cartInfo = cart.GetCartInfo();
            foreach (var info in cartInfo)
            {
                lstCart.Items.Add(info);
            }
            lblTotalPrice.Text = $"Łączna wartość: {cart.GetTotalPrice():C}";
        }
    }
}
