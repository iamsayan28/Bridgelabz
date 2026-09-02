abstract class Product
{
    public string Name { get; protected set; }
    public double Price { get; protected set; }
    public Product(string name, double price)
    {
        Name = name;
        Price = Price;
    }

    public virtual void ShippingCosts(int cost)
    {
        Price += cost;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Product Name : ");
    }
}

class PhysicalProduct : Product
{
    public PhysicalProduct(string name, double price) : base(name, price) { }
}

class DigitalProduct : Product
{
    public DigitalProduct(string name, double price) : base(name, price) { }
}