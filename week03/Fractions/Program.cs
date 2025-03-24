using System;

using System;

class Program
{
    static void Main()
    {
        // Testing different constructors
        Fraction frac1 = new Fraction(); 
        Fraction frac2 = new Fraction(6);
        Fraction frac3 = new Fraction(6, 7);

        Console.WriteLine($"Fraction 1: {frac1.GetFractionString()} = {frac1.GetDecimalValue()}");
        Console.WriteLine($"Fraction 2: {frac2.GetFractionString()} = {frac2.GetDecimalValue()}");
        Console.WriteLine($"Fraction 3: {frac3.GetFractionString()} = {frac3.GetDecimalValue()}");

        // Testing setters and getters
        frac1.SetNumerator(3);
        frac1.SetDenominator(4);

        Console.WriteLine($"Last Fraction: {frac1.GetFractionString()} = {frac1.GetDecimalValue()}");
    }
}
