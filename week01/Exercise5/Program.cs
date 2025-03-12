using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to my assingment of functions with C#.");
        }

        static string PromptUserName()
        {
            Console.WriteLine("What is your name?");
            string response = Console.ReadLine();
            return response;
        }

        static int PromptUserNumber()
        {
            Console.WriteLine("What is your favorite number?");
            int response = int.Parse(Console.ReadLine());
            return response;
        }

        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"Dear {name}, the square of your favorite number is {square}.");
            
        }
    
}