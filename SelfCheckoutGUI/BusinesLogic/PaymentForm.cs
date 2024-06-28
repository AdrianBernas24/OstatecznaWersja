using System.Windows.Forms;

namespace SelfCheckoutApp.GUI
{
    public class PaymentForm : Form
    {
        private ShoppingCart cart;

        public PaymentForm(ShoppingCart shoppingCart)
        {
            cart = shoppingCart;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Implementacja UI formularza
        }
    }
}
