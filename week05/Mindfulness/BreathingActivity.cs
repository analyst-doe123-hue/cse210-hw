using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", 
               "This activity helps you relax by guiding you through slow breathing.") { }

    public override void PerformActivity()
    {
        Console.WriteLine("\nFocus on your breathing...");

        int cycles = _duration / 8; // one cycle = 4 inhale + 4 exhale seconds
        for (int i = 0; i < cycles; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Inhale... ");
            Console.ResetColor();
            ShowCountDown(4);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Exhale... ");
            Console.ResetColor();
            ShowCountDown(4);

            Console.WriteLine();
        }
    }
}
