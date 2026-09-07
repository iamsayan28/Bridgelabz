using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
//using System.Reflection;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DeveloperInfoAttribute : Attribute
{
    public string Name { get; }
    public string LastModified { get; }

    public DeveloperInfoAttribute(string name, string lastModified)
    {
        Name = name;
        LastModified = lastModified;
    }
}

[DeveloperInfo("Alice", "2026-08-15")]
public class PaymentProcessor
{
    [DeveloperInfo("Bob", "2026-09-01")]
    public void ProcessCreditCard()
    {
        Console.WriteLine("Processing card...");
    }
}

class UseOfReflectionOnAttributes
{
    static void Main(string[] args)
    {
        Type classType = typeof(PaymentProcessor);
        object[] attributes = classType.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);

        foreach (DeveloperInfoAttribute att in attributes)
        {
            Console.WriteLine(att.Name);
        }

        MethodInfo methodType = classType.GetMethod("ProcessCreditCard");
        object[] methodattr = methodType.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);
        Console.WriteLine(methodattr);

        foreach(DeveloperInfoAttribute att in methodattr)
        {
            Console.WriteLine(att.Name);
        }
    }
}
