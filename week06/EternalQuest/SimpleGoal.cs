using System;

/// <summary>
/// Represents a one-time goal that can be completed once.
/// Inherits from Goal and overrides abstract methods.
/// Demonstrates polymorphism.
/// </summary>
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Marks goal as complete once and awards points
    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ Goal '{_name}' completed! You earned {_points} points!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\n⚠️ This goal has already been completed.");
        }
    }

    // Returns whether the goal is completed
    public override bool IsComplete() => _isComplete;

    // Displays goal with checkmark status
    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    // Converts goal data into a savable string format
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}
