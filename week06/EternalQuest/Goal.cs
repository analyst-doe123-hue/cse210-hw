using System;

/// <summary>
/// ABSTRACT BASE CLASS: Goal
/// Defines shared structure and behavior for all goal types.
/// Demonstrates abstraction and inheritance.
/// </summary>
public abstract class Goal
{
    // Protected so derived classes can access directly (Encapsulation principle)
    protected string _name;
    protected string _description;
    protected int _points;

    // Base constructor (used by all goal types)
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Getter methods (data encapsulation)
    public string GetName() => _name;
    public int GetPoints() => _points;

    // Abstract methods (Polymorphism: to be overridden by derived classes)
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
