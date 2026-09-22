public class EmployeeValidationTests
{
    private EmployeeValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new EmployeeValidator();
    }

    [Test]
    public void Validate_ValidEmployee_ReturnsTrue()
    {
        var emp = new Employee(101, "Alice", "alice@example.com", "IT", "Engineer", 50000, DateTime.Today.AddDays(-10), "FullTime", "Active");
        bool isValid = _validator.Validate(emp, out var errors);
        Assert.That(isValid, Is.True);
        Assert.That(errors, Is.Empty);
    }

    [Test]
    public void Validate_InvalidEmail_ReturnsFalse()
    {
        var emp = new Employee(102, "Bob", "bob-invalid-email", "HR", "Manager", 60000, DateTime.Today, "FullTime", "Active");
        bool isValid = _validator.Validate(emp, out var errors);
        Assert.That(isValid, Is.False);
        Assert.That(errors, Does.Contain("Invalid email address."));
    }

    [Test]
    public void Validate_NegativeSalary_ReturnsFalse()
    {
        var emp = new Employee(103, "Charlie", "charlie@test.com", "IT", "Developer", -10, DateTime.Today, "FullTime", "Active");
        bool isValid = _validator.Validate(emp, out var errors);
        Assert.That(isValid, Is.False);
        Assert.That(errors, Does.Contain("Salary must be greater than 0."));
    }

    [Test]
    public void Validate_FutureJoiningDate_ReturnsFalse()
    {
        var emp = new Employee(104, "David", "david@test.com", "Finance", "Analyst", 40000, DateTime.Today.AddDays(5), "FullTime", "Active");
        bool isValid = _validator.Validate(emp, out var errors);
        Assert.That(isValid, Is.False);
        Assert.That(errors, Does.Contain("Joining date cannot be in the future."));
    }

    [Test]
    public void Validate_InvalidDepartment_ReturnsFalse()
    {
        var emp = new Employee(105, "Eve", "eve@test.com", "InvalidDept", "Lead", 70000, DateTime.Today, "FullTime", "Active");
        bool isValid = _validator.Validate(emp, out var errors);
        Assert.That(isValid, Is.False);
        Assert.That(errors, Does.Contain("Department not accepted."));
    }
}
