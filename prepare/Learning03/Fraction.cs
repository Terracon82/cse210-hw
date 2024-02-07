class Fraction
{
    private double _numerator;
    private double _denominator;
    public double Numerator { get { return _numerator; } set { _numerator = value; } }
    public double Denominator { get { return _denominator; } set { _denominator = value; } }

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }
    public double GetDecimalValue()
    {
        return _numerator / _denominator;
    }
}