using System;
using System.Collections.Generic;

namespace SelfCheckoutApp.GUI
{
    public class ShoppingCart
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddProduct(FoodProduct product, int quantity)
        {
            var existingItem = items.Find(i => i.Product.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
            Console.WriteLine($"{quantity} x {product.Name} dodano do koszyka.");
        }

        public void RemoveProduct(string productName, int quantity)
        {
            var item = items.Find(i => i.Product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                if (item.Quantity <= quantity)
                {
                    items.Remove(item);
                    Console.WriteLine($"{item.Product.Name} całkowicie usunięto z koszyka.");
                }
                else
                {
                    item.Quantity -= quantity;
                    Console.WriteLine($"{quantity} x {item.Product.Name} usunięto z koszyka.");
                }
            }
            else
            {
                Console.WriteLine("Produkt nie znaleziony w koszyku.");
            }
        }

        public List<string> GetCartInfo()
        {
            List<string> cartInfo = new List<string>();
            foreach (var item in items)
            {
                cartInfo.Add(item.GetInfo());
            }
            return cartInfo;
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.GetTotalPrice();
            }
            return total;
        }

        public void ClearCart()
        {
            items.Clear();
            Console.WriteLine("Koszyk został opróżniony.");
        }
    }
}
