class Fraction1
{
    private int _numerator;
    private int _denominator;

    public Fraction1()
    {
        _numerator = 1;
        _denominator = 1;
    }
    public Fraction1(int wholenumber)
    {
        _numerator = wholenumber;
        _denominator = 1;
    }

    public Fraction1(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    public int GetNumerator()
    {
        return _numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }
    public double ToDouble()
    {
        return (double)_numerator / _denominator;
    }

    public override string ToString()
    {
        return $"{_numerator}/{_denominator}";
    }
}