// 1. Smart Warehouse Management System
abstract class WarehouseItem
{
    private int itemId;
    private string itemName;
    private double itemPrice;

    public WarehouseItem(int itemId, string itemName, double itemPrice)
    {
        this.itemId = itemId;
        this.itemName = itemName;
        this.itemPrice = itemPrice;
    }
    public int ItemId { get => itemId; set => itemId = value; }
    public string ItemName { get => itemName; set => itemName= value; }
    public double ItemPrice { get => itemPrice; set => itemPrice = value; }
}

class Electronics : WarehouseItem
{
    public Electronics(int itemId, string itemName, double itemPrice) : base( itemId, itemName, itemPrice) { }

    public Electronics(int itemId, string itemName) : this(itemId, itemName, 0) { }
    public Electronics(int itemId) : this(itemId, "Nameless-Electronics", 0) { }
    public Electronics() : this(0, "Nameless-Electronics", 0) { }
}

class Grocceries : WarehouseItem
{
    public Grocceries(int itemId, string itemName, double itemPrice) : base(itemId, itemName, itemPrice) { }
    public Grocceries(int itemId, string itemName) : this(itemId, itemName, 0) { }
    public Grocceries(int itemId) : this(itemId, "Nameless-Groccery", 0) { }

}
class Furniture : WarehouseItem
{
    public Furniture(int itemId, string itemName, double itemPrice) : base(itemId, itemName, itemPrice) { }
    public Furniture(int itemId, string itemName) : this(itemId, itemName, 0) { }
    public Furniture(int itemId) : this(itemId, "Nameless-Furniture", 0) { }
}

// Bounded-Type Generic Params for class Storage 
class Storage<T> where T : WarehouseItem
{
    public void DisplayItems(List<T> items)
    {
        foreach (T item in items)
        {
            Console.WriteLine($"Display of {typeof(T).Name} items");
            Console.WriteLine($"Item ID: {item.ItemId}, Item Name: {item.ItemName}, Item Price: {item.ItemPrice}");
        }
        Console.WriteLine();
    }
}


// 2. Dynamic Online Marketplace
abstract class ProductCategory
{
    public string Name { get; }

    protected ProductCategory(string name)
    {
        Name = name;
    }
}

class BookCategory : ProductCategory
{
    public BookCategory(string name) : base(name)
    {
    }
}

class ClothingCategory : ProductCategory
{
    public ClothingCategory(string name) : base(name)
    {
    }
}

class Product<T> where T : ProductCategory
{
    public string ProductName { get; }
    public double Price { get; set; }
    public T Category { get; }

    public Product(string productName, double price, T category)
    {
        ProductName = productName;
        Price = price;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine($"{ProductName}, Category: {Category.Name}, Price: {Price}");
    }
}
class Marketplace
{
    public void ApplyDiscount<T>(Product<T> product, double percentage)
        where T : ProductCategory
    {
        product.Price -= product.Price * percentage / 100;
    }
}

// MAIN 
class GenericsAssignment
{
    static void Main(string[] args)
    {
        List<WarehouseItem> warehouseItems = new List<WarehouseItem>();
        Electronics e1 = new Electronics();
        Electronics e2 = new Electronics(1, "TV", 10000);
        Electronics e3 = new Electronics(2, "Fridge", 15000);
        Grocceries g1 = new Grocceries(1, "Sweet Potato", 25);

        warehouseItems.Add(e1);
        warehouseItems.Add(e2);
        warehouseItems.Add(e3);
        warehouseItems.Add(g1);

        List<Electronics> eItems = new List<Electronics>();

        eItems.Add(e1);
        eItems.Add(e2);
        eItems.Add(e3);
        
        Storage<WarehouseItem> warehouseStorage = new Storage<WarehouseItem>();
        Storage<Electronics> electronicsStorage = new Storage<Electronics>();
        
        warehouseStorage.DisplayItems(warehouseItems);
        electronicsStorage.DisplayItems(eItems);

        // 2.
        BookCategory programmingBook = new BookCategory("Programming Books");

        ClothingCategory mensClothing = new ClothingCategory("Men's Clothing");

        Product<BookCategory> book = new Product<BookCategory>("C# Fundamentals", 500, programmingBook);
        Product<ClothingCategory> shirt = new Product<ClothingCategory>("Cotton Shirt",800, mensClothing);

        Console.WriteLine("ONLINE MARKETPLACE");
        Console.WriteLine();

        book.Display();
        shirt.Display();

        Marketplace marketplace = new Marketplace();

        marketplace.ApplyDiscount(book, 10);
        marketplace.ApplyDiscount(shirt, 20);

        Console.WriteLine();
        Console.WriteLine("After Discount:");

        book.Display();
        shirt.Display();
    }
}