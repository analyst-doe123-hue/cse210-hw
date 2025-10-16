using System;

public abstract class Activity
{
    // Shared attributes for all activities
    private DateTime _date;
    private int _minutes;

    // Constructor
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Encapsulation: Getters
    public DateTime GetDate() => _date;
    public int GetMinutes() => _minutes;

    // Abstract methods for polymorphism
    public abstract double GetDistance(); // miles or km
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // min per mile or km

    // Shared summary method using other methods
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.00}, Speed: {GetSpeed():0.00}, Pace: {GetPace():0.00} min/unit";
    }
}
