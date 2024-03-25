using System.Net.Sockets;

class Customer
{
    private string _name;
    public string Name { get { return _name; } }
    private Address _address;
    public bool InUSA { get { return _address.InUSA; } }
    public string Address { get { return _address.DisplayAddress; } }

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
}