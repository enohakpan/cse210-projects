using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int suggestion = -1;
        while (suggestion != 0)
        {
            Console.WriteLine("Suggest a number that is greater than 0 (type 0 to stop)");
            string userResponse = Console.ReadLine();
            suggestion = int.Parse(userResponse);

            if (suggestion != 0)
            {
                numbers.Add(suggestion);
            }

            else
            {
                int sum = 0;
                foreach (int num in numbers)
                {
                    sum += num;
                }
                Console.WriteLine($"The sum is: {sum}");
                float average = ((float)sum) / numbers.Count;
                Console.WriteLine($"The average is: {average}");

                int max = numbers[0];

                foreach (int number in numbers)
                {
                    if (number > max)
                    {
                        max = number;
                    }
                }

                Console.WriteLine($"The largest number is: {max}");
            }

            
        }
    }
}