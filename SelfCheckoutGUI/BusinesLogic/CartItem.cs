namespace SelfCheckoutApp.GUI
{
    public class CartItem
    {
        public FoodProduct Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(FoodProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }

        public string GetInfo()
        {
            return $"{Product.Name}, Ilość: {Quantity}, Cena jednostkowa: {Product.Price:C}, Łączna cena: {GetTotalPrice():C}";
        }
    }
}
