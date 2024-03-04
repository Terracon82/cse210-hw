abstract class Shape
{
    protected string _color;
    public string Color { get { return _color; } set { string color = _color; } }

    public Shape(string color)
    {
        _color = color;
    }

    public abstract double GetArea();
}