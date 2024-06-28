using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace SelfCheckoutApp.GUI
{
    public class Database
    {
        private string connectionString = "server=localhost;database=selfcheckout;user=root;password=;";

        public List<FoodProduct> GetProducts()
        {
            List<FoodProduct> products = new List<FoodProduct>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT name, price, category FROM products", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("name");
                    decimal price = reader.GetDecimal("price");
                    string category = reader.GetString("category");
                    FoodProduct product = null;
                    switch (category.ToLower())
                    {
                        case "bakery":
                            product = new Bakery(name, price);
                            break;
                        case "vegetable":
                            product = new Vegetable(name, price);
                            break;
                        case "fruit":
                            product = new Fruit(name, price);
                            break;
                        case "dairy":
                            product = new Dairy(name, price);
                            break;
                        case "beverage":
                            product = new Beverage(name, price);
                            break;
                    }
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}
