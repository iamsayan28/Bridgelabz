// TaskInfo is an attribute that assigns to methods with the priority
// and the person responsible for the method

[AttributeUsage(AttributeTargets.Method)]
class TaskInfo : Attribute
{   
    public string AssignedTo { get; }
    public string Priority { get; }
    public TaskInfo(string name, string priority)
    {
        AssignedTo = name;
        Priority = priority;
    }
}

class TaskManager
{
    [TaskInfo("Sayan", "High")]
    public void method1()
    {
        Console.WriteLine("Task completed");
    }
}

//----------------------------------------------------
// 1. BugReport
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class BugReportAttribute : Attribute
{
    public string Description { get; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// 2. ImportantMethod
[AttributeUsage(AttributeTargets.Method)]
public class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

// 3. Todo
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TodoAttribute : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }
    public string Priority { get; }

    public TodoAttribute(
        string task,
        string assignedTo,
        string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// 4. LogExecutionTime
[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTimeAttribute : Attribute
{
}

// 5. MaxLength
[AttributeUsage(AttributeTargets.Field)]
public class MaxLengthAttribute : Attribute
{
    public int Value { get; }

    public MaxLengthAttribute(int value)
    {
        Value = value;
    }
}

// 6. RoleAllowed
[AttributeUsage(AttributeTargets.Method)]
public class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

// 7. JsonField
[AttributeUsage(AttributeTargets.Field)]
public class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
}

// 8. CacheResult
[AttributeUsage(AttributeTargets.Method)]
public class CacheResultAttribute : Attribute
{
}