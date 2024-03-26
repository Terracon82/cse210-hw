abstract class Activity
{
    private string _date;
    protected double _duration;
    public virtual double Distance { get; }
    public double Speed { get { return Distance / (_duration / 60); } }
    public double Pace { get { return _duration / Distance; } }

    public string Summary
    {
        get
        {
            return $"""
            {_date} {this.GetType()} ({Math.Round(_duration, 2)} min): Distance {Math.Round(Distance, 2)} km, Speed: {Math.Round(Speed, 2)} kph, Pace: {Math.Round(Pace, 2)} min per km
            """;
        }
    }

    public Activity(string date, double duration)
    {
        _date = date;
        _duration = duration;
    }


}