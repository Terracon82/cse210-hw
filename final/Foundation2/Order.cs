class Order
{
    private List<Product> _products;
    private Customer _customer;

    public string ShippingLabel { get { return $"{_customer.Name}, {_customer.Address}"; } }
    public string PackingLabel
    {
        get
        {
            string returnString = "";
            foreach (Product product in _products)
            {
                returnString += product.Name + " - " + product.ProductID + "\n";
            }
            return returnString;
        }
    }

    public double TotalPrice { get { return _products.Sum(product => product.Price) + ShippingCost; } }

    private double ShippingCost
    {
        get
        {
            if (_customer.InUSA)
            {
                return 5;
            }
            else
            {
                return 35;
            }
        }
    }

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }
}