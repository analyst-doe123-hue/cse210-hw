using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "List as many things as you are grateful for today.",
        "List people who have influenced you positively.",
        "List things that make you smile."
    };

    public ListingActivity()
        : base("Listing Activity", 
               "This activity helps you recognize the good things in your life.") { }

    public override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n→ {prompt}");
        Console.WriteLine("You will have time to list as many responses as you can...");
        ShowSpinner(3);
        Console.WriteLine("Start listing items now! (Press Enter after each)");

        List<string> responses = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                    responses.Add(item);
            }
        }

        Console.WriteLine($"\nTime's up! You listed {responses.Count} items. Great job!");
    }
}
