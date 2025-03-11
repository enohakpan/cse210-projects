using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int numOfGuess = 0;

        while (guess  != magicNumber)
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
            numOfGuess += 1;
            

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }

            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            else 
            {
                Console.WriteLine($"Correct after trying {numOfGuess} times");
            }
        }
    }
}