using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you helped someone in need.",
        "Recall a moment you felt proud of an accomplishment.",
        "Remember a time when you overcame a challenge."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "What did you learn from it?",
        "How can you apply that lesson in your life today?",
        "How did it make you feel afterwards?"
    };

    public ReflectingActivity()
        : base("Reflecting Activity", 
               "This activity helps you reflect on times when you showed strength or resilience.") { }

    public override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nConsider this prompt:\n→ {prompt}\n");
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();
        Console.WriteLine("Now ponder the following questions...");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string question = _questions[i % _questions.Count];
            Console.Write($"\n{question} ");
            ShowSpinner(5);
            i++;
        }
    }
}
