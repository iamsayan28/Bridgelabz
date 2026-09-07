using System.Reflection;

class LegacyAPI
{

    [Obsolete("Avoid using this method")]
    public void OldFeature()
    {
        Console.WriteLine("Old feature");
    }
}

class Program
{
    static void Main(string[] args)
    {
        LegacyAPI legacyApi = new LegacyAPI();
        legacyApi.OldFeature(); // Ran but gave a warning in error list

        // ex-4
        TaskManager taskManager = new TaskManager();
        Type objType = typeof(TaskManager);

        MethodInfo method = objType.GetMethod("method1"); // .GetMethods -> Gets all the methods but here we want to work with Attributes on methods with TaskInfo
        TaskInfo attribute = (TaskInfo) method.GetCustomAttribute(typeof(TaskInfo));
        Console.WriteLine(attribute.AssignedTo);
        Console.WriteLine(attribute.Priority);
    }
}