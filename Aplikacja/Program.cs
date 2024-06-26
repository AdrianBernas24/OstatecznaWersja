﻿using System;
using System.Collections.Generic;

namespace SelfCheckout
{
    // Klasa produktów spożywczych
    public class FoodProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public FoodProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Produkt: {Name}, Cena: {Price:C}");
        }
    }

    // Klasa warzywa
    public class Vegetable : FoodProduct
    {
        public Vegetable(string name, decimal price)
            : base(name, price) { }
    }

    // Klasa owoce
    public class Fruit : FoodProduct
    {
        public Fruit(string name, decimal price)
            : base(name, price) { }
    }

    // Klasa pieczywa
    public class Bakery : FoodProduct
    {
        public Bakery(string name, decimal price)
            : base(name, price) { }
    }

    // Klasa nabiał
    public class Dairy : FoodProduct
    {
        public Dairy(string name, decimal price)
            : base(name, price) { }
    }

    // Klasa napoje
    public class Beverage : FoodProduct
    {
        public Beverage(string name, decimal price)
            : base(name, price) { }
    }

    // Klasa dla elementu koszyka zakupowego
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

        public void DisplayInfo()
        {
            Console.WriteLine($"{Product.Name}, Ilość: {Quantity}, Cena jednostkowa: {Product.Price:C}, Łączna cena: {GetTotalPrice():C}");
        }
    }

    // Klasa dla koszyka zakupowego
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
            Console.Clear();
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

        public void DisplayCart()
        {
            Console.WriteLine("Zawartość koszyka:");
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
            Console.WriteLine($"Łączna wartość: {GetTotalPrice():C}");
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

    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            // Inicjalizacja listy produktów za pomocą ProductFactory
            var products = ProductFactory.CreateProducts();

            bool isShopping = true;
            while (isShopping)
            {
                Console.Clear();
                Console.WriteLine("Wybierz działanie:");
                Console.WriteLine("1. Dodaj produkt do koszyka");
                Console.WriteLine("2. Edytuj koszyk");
                Console.WriteLine("3. Zapłać");
                Console.WriteLine("4. Wyjdź");
                Console.Write("Twój wybór: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        SelectProductCategory(cart, products);
                        break;
                    case 2:
                        Console.Clear();
                        EditCart(cart);
                        break;
                    case 3:
                        Console.Clear();
                        Checkout(cart);
                        break;
                    case 4:
                        isShopping = false;
                        Console.WriteLine("Dziękujemy za skorzystanie z kasy samoobsługowej!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void SelectProductCategory(ShoppingCart cart, List<FoodProduct> products)
        {
            bool selecting = true;
            while (selecting)
            {
                Console.Clear();
                Console.WriteLine("Wybierz kategorię produktów:");
                Console.WriteLine("1. Pieczywo");
                Console.WriteLine("2. Warzywa");
                Console.WriteLine("3. Owoce");
                Console.WriteLine("4. Nabiał");
                Console.WriteLine("5. Napoje");
                Console.WriteLine("6. Powrót do menu głównego");
                Console.Write("Twój wybór: ");
                int categoryChoice = int.Parse(Console.ReadLine());

                switch (categoryChoice)
                {
                    case 1:
                        Console.Clear();
                        AddProductToCart(cart, products.FindAll(p => p is Bakery));
                        break;
                    case 2:
                        Console.Clear();
                        AddProductToCart(cart, products.FindAll(p => p is Vegetable));
                        break;
                    case 3:
                        Console.Clear();
                        AddProductToCart(cart, products.FindAll(p => p is Fruit));
                        break;
                    case 4:
                        Console.Clear();
                        AddProductToCart(cart, products.FindAll(p => p is Dairy));
                        break;
                    case 5:
                        Console.Clear();
                        AddProductToCart(cart, products.FindAll(p => p is Beverage));
                        break;
                    case 6:
                        selecting = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void AddProductToCart(ShoppingCart cart, List<FoodProduct> products)
        {
            bool adding = true;
            while (adding)
            {
                Console.WriteLine("Dostępne produkty:");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:C}");
                }
                Console.WriteLine($"{products.Count + 1}. Powrót do wyboru kategorii");
                Console.Write("Wybierz produkt do dodania: ");
                int productIndex = int.Parse(Console.ReadLine()) - 1;

                if (productIndex == products.Count)
                {
                    adding = false;
                }
                else if (productIndex >= 0 && productIndex < products.Count)
                {
                    Console.Write("Podaj ilość: ");
                    int quantity = int.Parse(Console.ReadLine());
                    cart.AddProduct(products[productIndex], quantity);
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór produktu. Spróbuj ponownie.");
                }
            }
        }

        static void EditCart(ShoppingCart cart)
        {
            bool editing = true;
            while (editing)
            {
                Console.Clear();
                cart.DisplayCart();
                Console.WriteLine("Wybierz działanie:");
                Console.WriteLine("1. Usuń produkt z koszyka");
                Console.WriteLine("2. Wróć do menu głównego");
                Console.Write("Twój wybór: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Podaj nazwę produktu do usunięcia: ");
                        string productName = Console.ReadLine();
                        Console.Write("Podaj ilość do usunięcia: ");
                        int quantity = int.Parse(Console.ReadLine());
                        cart.RemoveProduct(productName, quantity);
                        break;
                    case 2:
                        editing = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void Checkout(ShoppingCart cart)
        {
            cart.DisplayCart();
            decimal totalPrice = cart.GetTotalPrice();
            Console.WriteLine($"Do zapłaty: {totalPrice:C}");
            Console.Write("Wpisz kwotę płatności: ");
            decimal payment = decimal.Parse(Console.ReadLine());

            if (payment >= totalPrice)
            {
                decimal change = payment - totalPrice;
                Console.WriteLine($"Płatność zakończona sukcesem. Dziękujemy za zakupy! Twoja reszta: {change:C}");
                cart.ClearCart();
            }
            else
            {
                Console.WriteLine("Niepoprawna kwota. Spróbuj ponownie.");
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu głównego...");
            Console.ReadKey();
        }
    }
}
