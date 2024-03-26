class Reception : Event
{
    private string _rsvpEmail;
    public override string FullDetails => base.FullDetails + $"RSVP Email: {_rsvpEmail}";

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail) : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }
}