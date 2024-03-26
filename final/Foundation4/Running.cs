class Running : Activity
{
    private double _distance;

    public override double Distance => _distance;

    public Running(string date, double duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }
}