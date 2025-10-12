using System;

/// <summary>
/// Represents a goal that must be completed multiple times (checklist).
/// Awards a bonus when fully completed.
/// Demonstrates polymorphism and encapsulation.
/// </summary>
public class ChecklistGoal : Goal
{
    private int _targetCount;   // Required completions
    private int _currentCount;  // Current completions
    private int _bonus;         // Bonus points on completion

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    // Record progress and award points or bonus
    public override void RecordEvent()
    {
        _currentCount++;

        if (_currentCount < _targetCount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nProgress: {_currentCount}/{_targetCount} - Earned {_points} points!");
        }
        else if (_currentCount == _targetCount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n🏆 Goal '{_name}' completed! Bonus {_bonus} points awarded!");
        }
        else
        {
            Console.WriteLine("\nThis goal is already completed.");
        }
        Console.ResetColor();
    }

    // Determines if the goal is complete
    public override bool IsComplete() => _currentCount >= _targetCount;

    // Display progress with visual status
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Progress: {_currentCount}/{_targetCount}";
    }

    // Converts to string for file saving
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}
