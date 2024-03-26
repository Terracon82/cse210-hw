class Outdoor : Event
{
    private string _weather;

    public override string FullDetails => base.FullDetails + $"Weather: {_weather}";

    public Outdoor(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
    }
}