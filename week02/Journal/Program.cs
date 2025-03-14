using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Journal application.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Choose an option:");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                myJournal.AddEntry();
            }
            else if (choice == "2")
            {
                myJournal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to load: ");
                string fileName = Console.ReadLine();
                myJournal.LoadFromFile(fileName);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");
                string fileName = Console.ReadLine();
                myJournal.SaveToFile(fileName);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}