
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\simso\samples";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();

            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory {newDirectory} and File {fileName} already exists at {rootDirectory}");

            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
            }
            string[] arrayFromFile = File.ReadAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}");
            List<string> ShoppingList = arrayFromFile.ToList<string>();

            foreach (string item in ShoppingList)
            {
                Console.WriteLine($"Your shopping list: {item}");
            }
            bool loopActive = true;
            while (loopActive)
            {
                Console.WriteLine("Would you like to add an item to your shopping list? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());
                if (userInput == 'y')
                {
                    Console.WriteLine("Enter shopping list item:");
                    string userItem = Console.ReadLine();
                    ShoppingList.Add(userItem);
                }
                else
                {
                    loopActive = false;
                    Console.Clear();

                    foreach (string item in ShoppingList)
                    {
                        Console.WriteLine($"Your shopping list: {item}");
                    }

                    File.WriteAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}", ShoppingList);
                }
            }
        }
    }
}