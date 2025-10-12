using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Mindfulness Activities";
        string choice = "";

        while (choice != "4")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== Mindfulness Program Menu ===");
            Console.ResetColor();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye! Stay mindful 🌿");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            activity.DisplayStartingMessage();
            activity.PerformActivity();
            activity.DisplayEndingMessage();
        }
    }
}
