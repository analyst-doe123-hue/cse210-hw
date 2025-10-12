using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Manages all goals and user interactions.
/// Handles creating, listing, saving, and loading goals.
/// Demonstrates encapsulation and polymorphism through lists of Goal objects.
/// </summary>
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>(); // Stores all goals (polymorphic list)
    private int _score = 0; // User's total score

    /// <summary>
    /// Main loop to handle menu options and user input
    /// </summary>
    public void Start()
    {
        Console.Clear();
        bool quit = false;

        while (!quit)
        {
            // Display current score in magenta
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n🏅 Current Score: {_score}\n");
            Console.ResetColor();

            // Main menu
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();
            Console.Clear();

            // Handle user selection
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": quit = true; break;
                default: Console.WriteLine("Invalid option. Please try again."); break;
            }
        }
    }

    /// <summary>
    /// Creates a new goal based on user selection.
    /// </summary>
    private void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points for completion: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (typeChoice == "1")
            goal = new SimpleGoal(name, desc, points);
        else if (typeChoice == "2")
            goal = new EternalGoal(name, desc, points);
        else if (typeChoice == "3")
        {
            Console.Write("How many times must it be completed? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points for completion: ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, desc, points, target, bonus);
        }

        if (goal != null)
        {
            _goals.Add(goal);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🎯 Goal created successfully!");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Displays all goals with progress and status.
    /// </summary>
    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    /// <summary>
    /// Records completion of a selected goal and awards points.
    /// </summary>
    private void RecordEvent()
    {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();

            // Add extra points if checklist goal is complete
            if (_goals[index] is ChecklistGoal cg && cg.IsComplete())
                _score += 50;
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    /// <summary>
    /// Saves current goals and score to a file.
    /// </summary>
    private void SaveGoals()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
                writer.WriteLine(g.GetStringRepresentation());
        }

        Console.WriteLine("\n💾 Goals saved successfully!");
    }

    /// <summary>
    /// Loads goals and score from a saved file.
    /// </summary>
    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("⚠️ File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        // Deserialize goals from file
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])));
        }

        Console.WriteLine("\n📂 Goals loaded successfully!");
    }
}
