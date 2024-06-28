using System.Windows.Forms;

namespace SelfCheckoutApp.GUI
{
    public class EditCartForm : Form
    {
        private ShoppingCart cart;

        public EditCartForm(ShoppingCart shoppingCart)
        {
            cart = shoppingCart;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EditCartForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "EditCartForm";
            this.Load += new System.EventHandler(this.EditCartForm_Load);
            this.ResumeLayout(false);

        }

        private void EditCartForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
