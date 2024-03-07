﻿using System;
public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    // Sell an item
    public void SellItem(int quantitySold)
    {
        if ((QuantityInStock - quantitySold) < 0)
        {
            Console.WriteLine("Not Enough Quantity.");
        }
        else
        {
            QuantityInStock = QuantityInStock - quantitySold;
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}, Item ID: {ItemId}, Price: ${Price}, Quantity in Stock: {QuantityInStock}");
    }
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter item name:");
        string itemName = Console.ReadLine();

        Console.WriteLine("Enter item ID:");
        int itemId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter price:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter quantity in stock:");
        int quantityInStock = int.Parse(Console.ReadLine());

        InventoryItem item = new InventoryItem(itemName, itemId, price, quantityInStock);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Print item details");
            Console.WriteLine("2. Sell item");
            Console.WriteLine("3. Restock item");
            Console.WriteLine("4. Check if item is in stock");
            Console.WriteLine("5. Update price");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    item.PrintDetails();
                    break;
                case "2":
                    Console.WriteLine("Enter quantity to sell:");
                    int quantitySold = int.Parse(Console.ReadLine());
                    item.SellItem(quantitySold);

                    break;
                case "3":
                    Console.WriteLine("Enter additional quantity to restock:");
                    int additionalQuantity = int.Parse(Console.ReadLine());
                    item.RestockItem(additionalQuantity);
                    Console.WriteLine("Item restocked.");
                    break;
                case "4":
                    Console.WriteLine(item.ItemName + " is " + (item.IsInStock() ? "in stock." : "not in stock."));
                    break;
                case "5":
                    Console.WriteLine("Enter new price:");
                    double newPrice = double.Parse(Console.ReadLine());
                    item.UpdatePrice(newPrice);
                    Console.WriteLine("Price is updated.");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, Please try again.");
                    break;
            }
        }
    }
}

