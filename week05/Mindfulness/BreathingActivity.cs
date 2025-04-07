using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        int cycleTime = 6; // 3 seconds in + 3 seconds out
        int cycles = duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine();
            Console.WriteLine("Breathe in... ");
            ShowCountdown(3);
            Console.WriteLine();

            Console.WriteLine("Now breathe out... ");
            ShowCountdown(3);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
