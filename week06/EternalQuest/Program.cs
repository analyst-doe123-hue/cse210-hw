using System;
using System.Threading;

/// <summary>
/// Main program entry point for Eternal Quest.
/// Handles startup animation and launches GoalManager.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "🏅 Eternal Quest - Goal Tracker";

        // Display animated intro
        AnimateTitle();

        // Create a GoalManager instance and start program
        GoalManager manager = new GoalManager();
        manager.Start();
    }

    /// <summary>
    /// Animated welcome text for visual effect.
    /// </summary>
    static void AnimateTitle()
    {
        string title = "✨ Welcome to Eternal Quest ✨";
        foreach (char c in title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(c);
            Thread.Sleep(40);
        }
        Console.ResetColor();
        Console.WriteLine("\n");
    }
}
