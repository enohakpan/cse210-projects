using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your firstname?");
        string first = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("What is your lastname?");
        string last = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine($"Your name is {last}, {first} {last}");
    }
}