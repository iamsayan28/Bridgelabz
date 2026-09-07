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