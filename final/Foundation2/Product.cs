class Product
{
    private string _productID;
    public string ProductID { get { return _productID; } }
    private string _name;
    public string Name { get { return _name; } }
    private double _unitPrice;
    private int _quantity;
    public double Price { get { return _unitPrice * _quantity; } }

    public Product(string productID, string name, double unitPrice, int quantity)
    {
        _productID = productID;
        _name = name;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }
}