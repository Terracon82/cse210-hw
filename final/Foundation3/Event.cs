class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public string Details
    {
        get
        {
            return
            $"""
            Title: {_title}
            Description: {_description}
            Date: {_date}
            Time: {_time}
            Address: {_address.DisplayAddress}

            """;
        }
    }

    public virtual string FullDetails
    {
        get
        {
            return Details;
        }
    }

    public string ShortDescription
    {
        get
        {
            return
            $"""
            Event Type: {this.GetType()}
            Title: {_title}
            Date: {_date}

            """;
        }
    }

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }
}