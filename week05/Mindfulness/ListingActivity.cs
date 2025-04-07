using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List as many things as you can that you are grateful for.",
        "List the people who have influenced you in a positive way.",
        "List the personal strengths you have.",
        "List the things that make you smile."
    };

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("List prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You will have a few seconds to prepare...");
        ShowSpinner(3);

        Console.WriteLine("Start listing items now! Press Enter after each one:");
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadLine();
                itemCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items!");
        DisplayEndingMessage();
    }
}
