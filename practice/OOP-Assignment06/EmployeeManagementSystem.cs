// problem set 1
namespace EMS
{
    interface IDepartement
    {
        void AssignDepartment(string deptName);
        string GetDepartmentDetails();
    }

    abstract class Employee : IDepartement
    {
        private int employeeID;
        private string name;
        private double baseSalary;
        private string deptName;

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string Name { get => name; set => name = value; }
        public double BaseSalary { get => baseSalary; set => baseSalary = value; }

        public Employee(int id, string name, double baseSalary)
        {
            this.employeeID = id;
            this.name = name;
            this.baseSalary = baseSalary;
            this.deptName = "Unassigned";
        }

        public void AssignDepartment(string deptName)
        {
            this.deptName = deptName;
        }

        public string GetDepartmentDetails()
        {
            return $"Department: {deptName}";
        }

        public abstract double CalculateSalary();

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeID}, Name: {Name}, Dept.: {deptName}, Salary: {CalculateSalary()}");
        }

    }

    class FullTimeEmployee : Employee
    {
        private int workHours;
        public FullTimeEmployee(int id, string name, double baseSalary, int workHours) : base(id, name, baseSalary)
        {
            this.workHours = workHours;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + workHours * 50;
        }
    }

    class PartTimeEmployee : Employee
    {
        private int workHours;
        public PartTimeEmployee(int id, string name, double baseSalary, int workHours) : base(id, name, baseSalary)
        {
            this.workHours = workHours;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + workHours * 30;
        }
    }
}

// Problem set 2
namespace ECommerce
{
    abstract class Product 
    {
        private int productId;
        private string name;
        private double price;

        public Product(int productId, string name, double price)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
        }

        public int ProductId { get => productId; set => productId = value; } 
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public abstract double CalculateDiscount();
    }

    interface ITaxable
    {
        double CalculateTax();
        void GetTaxDetails();
    }

    class Electronics : Product, ITaxable
    {
        public Electronics(int productId, string name, double price) : base(productId, name, price)
        { }

        public override double CalculateDiscount()
        {
            return Price * 0.10; 
        }

        public double CalculateTax()
        {
            return Price * 0.18;
        }

        public void GetTaxDetails()
        {
            Console.WriteLine($"Electronics Tax Rate: 18% and Tax Amount: ${CalculateTax()}");
        }
    }

    class Clothing : Product, ITaxable
    {
        public Clothing(int productId, string name, double price) : base(productId, name, price)
        { }

        public override double CalculateDiscount()
        {
            return Price * 0.15;
        }

        public double CalculateTax()
        {
            return Price * 0.05; 
        }

        public void GetTaxDetails()
        {
            Console.WriteLine($"Clothing Product: {Name.ToUpper()}, Tax Rate: 5% and Tax Amount: ${CalculateTax()}");
        }
    }
    
    class Groceries : Product
    {
        public Groceries(int productId, string name, double price) : base(productId, name, price)
        { }

        public override double CalculateDiscount()
        {
            return Price * 0.05;
        }
    }

    
}
class OopProblems
{
    public static void Main(string[] args)
    {
        //1
        EMS.FullTimeEmployee fte = new EMS.FullTimeEmployee(101, "Alice", 60000, 5000);
        fte.Name = "Sayan";
        fte.DisplayDetails();

        //2
        ECommerce.Clothing cloth1 = new ECommerce.Clothing(1, "raymond", 2500);
        cloth1.Price = 1500;
        cloth1.GetTaxDetails();
    }
}