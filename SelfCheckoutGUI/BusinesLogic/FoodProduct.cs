namespace SelfCheckoutApp.GUI
{
    public class FoodProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public FoodProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string GetInfo()
        {
            return $"Produkt: {Name}, Cena: {Price:C}";
        }
    }
}
