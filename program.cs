using System;
using System.Collections.Generic;

namespace CoffeeShopApp
{
    
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public MenuItem(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class Menu
    {
        private List<MenuItem> items = new List<MenuItem>();

        public void AddItem(MenuItem item)
        {
            items.Add(item);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price:F2}");
            }
            Console.WriteLine("0. Finish Order");
        }

        public MenuItem GetItemById(int id)
        {
            return items.Find(item => item.Id == id);
        }
    }

   
    public class Order
    {
        private List<MenuItem> orderedItems = new List<MenuItem>();

        public void AddToOrder(MenuItem item)
        {
            orderedItems.Add(item);
            Console.WriteLine($"Added {item.Name} to your order.");
        }

        public void DisplayOrderSummary()
        {
            if (orderedItems.Count > 0)
            {
                Console.WriteLine("\nYour Order:");
                double total = 0;
                foreach (var item in orderedItems)
                {
                    Console.WriteLine($"- {item.Name}: ${item.Price:F2}");
                    total += item.Price;
                }
                Console.WriteLine($"Total: ${total:F2}");
                Console.WriteLine("Thank you for your order!");
            }
            else
            {
                Console.WriteLine("No items ordered. Thank you!");
            }
        }
    }

    
    public class CoffeeShopApp
    {
        private Menu menu;
        private Order order;

        public CoffeeShopApp()
        {
            menu = new Menu();
            order = new Order();

            
            menu.AddItem(new MenuItem(1, "Espresso", 2.50));
            menu.AddItem(new MenuItem(2, "Cappuccino", 3.00));
            menu.AddItem(new MenuItem(3, "Latte", 3.50));
            menu.AddItem(new MenuItem(4, "Americano", 2.75));
            menu.AddItem(new MenuItem(5, "Mocha", 3.75));
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the Coffee Shop!");
            bool ordering = true;

            while (ordering)
            {
                
                menu.DisplayMenu();

                
                Console.Write("Enter the number of the item you'd like to order (or 0 to finish): ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                    {
                        ordering = false;
                    }
                    else
                    {
                        var selectedItem = menu.GetItemById(choice);
                        if (selectedItem != null)
                        {
                            order.AddToOrder(selectedItem);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            
            order.DisplayOrderSummary();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeShopApp app = new CoffeeShopApp();
            app.Run();
        }
    }
}
