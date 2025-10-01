public class Fraction
{
    // Private attributes
    private int _numerator;
    private int _denominator;

    // No-arg constructor: 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // One-arg constructor: numerator given, denominator = 1
    public Fraction(int top)
    {
        _numerator = top;
        _denominator = 1;
    }

    // Two-arg constructor: numerator and denominator given
    public Fraction(int top, int bottom)
    {
        _numerator = top;
        _denominator = bottom;
    }

    // Getters and Setters
    public int GetNumerator() { return _numerator; }
    public void SetNumerator(int n) { _numerator = n; }

    public int GetDenominator() { return _denominator; }
    public void SetDenominator(int d) { _denominator = d; }

    // Return fraction as string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Return decimal value
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
