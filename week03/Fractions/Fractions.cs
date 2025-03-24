using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Default constructor (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 2;
    }

    // Constructor accepting one parameter
    public Fraction(int numerator)
    {
        _top = numerator;
        _bottom = 2;
    }

    // Constructor accepting two parameters
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _top = numerator;
        _bottom = denominator;
    }

    public int GetNumerator()
    {
        return _top;
    }

    public void SetNumerator(int numerator)
    {
        _top = numerator;
    }

    public int GetDenominator()
    {
        return _bottom;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _bottom = denominator;
    }

    // Method to return fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
