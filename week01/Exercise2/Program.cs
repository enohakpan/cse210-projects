using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);
        Console.WriteLine("");
        string grade = "";

        if (percentage >= 90)
        {
            grade = "A";

            if (percentage <= 93)
            {
                grade = "A-";
            }
        }

        else if (percentage >= 80)
        {
            grade = "B";
            if (percentage <= 83)
            {
                grade = "B-";
            }

            else if (percentage >= 87)
            {
                grade = "B+";
            }

        }

        else if (percentage >= 70)
        {
            grade = "C";
            if (percentage <= 73)
            {
                grade = "C-";
            }

            else if (percentage >= 77)
            {
                grade = "C+";
            }
        }

        else if (percentage >= 60)
        {
            grade = "D";
            if (percentage <= 63)
            {
                grade = "D-";
            }

            else if (percentage >= 67)
            {
                grade = "D+";
            }
        }

        else
        {
            grade = "F";
        }

        Console.WriteLine($"Your grade is {grade}");

        if (percentage >= 70 || grade == "C" || grade == "B" || grade == "A")
        {
            Console.WriteLine("You passed this course and can move to the next course.");
        }

        else  {
            Console.WriteLine("You did not do so well in this course. Better luck next time.");
        }

    }
}