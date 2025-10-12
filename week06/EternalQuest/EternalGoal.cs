using System;

/// <summary>
/// Represents a goal that can be recorded infinitely (e.g., daily habits).
/// Never marked as complete.
/// </summary>
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Awards points each time it's recorded (never complete)
    public override void RecordEvent()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n🌟 You completed '{_name}' and earned {_points} points!");
        Console.ResetColor();
    }

    // Eternal goals never complete
    public override bool IsComplete() => false;

    // Displays with infinity symbol
    public override string GetDetailsString()
    {
        return $"[∞] {_name} ({_description})";
    }

    // Saves goal data to file
    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}
