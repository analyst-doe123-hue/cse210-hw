using System;

public class Swimming : Activity
{
    private int _laps; // number of 50m laps

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Convert meters to miles
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();
}
