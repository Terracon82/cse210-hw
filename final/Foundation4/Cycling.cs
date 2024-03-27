class Cycling : Activity
{
    private double _speed;

    public override double Distance => _speed * (_duration / 60);

    public Cycling(string date, double duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }
}