using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;


// USER CLASS - for Exercise 4 and Exercise 
public class User
{
    [MaxLength(10)]
    [JsonField(Name = "user_name")]
    public string Username;

    public User(string username)
    {
        // Validate MaxLength attribute
        FieldInfo field =
            typeof(User).GetField("Username");

        MaxLengthAttribute attribute =
            field.GetCustomAttribute<MaxLengthAttribute>();

        if (username.Length > attribute.Value)
        {
            throw new ArgumentException(
                "Username cannot be longer than " +
                attribute.Value +
                " characters."
            );
        }
        Username = username;
    }
}

public class Program
{
    // EXERCISE 1: BugReport
    [BugReport("Null reference exception when input is empty")]
    [BugReport("Incorrect result when negative numbers are entered")]
    public static void ProcessData()
    {
        Console.WriteLine("Processing data...");
    }


    // ============================================================
    // EXERCISE 2: ImportantMethod
    [ImportantMethod]
    public static void Login()
    {
        Console.WriteLine("Login method");
    }

    [ImportantMethod("LOW")]
    public static void DisplayHelp()
    {
        Console.WriteLine("Help method");
    }


    // ============================================================
    // EXERCISE 2: Todo

    [Todo("Add input validation", "Rahul", "HIGH")]
    [Todo("Add logging functionality", "Amit")]
    public static void Calculate()
    {
        Console.WriteLine("Calculate method");
    }

    [Todo("Improve UI design", "Priya", "LOW")]
    public static void Display()
    {
        Console.WriteLine("Display method");
    }


    // ============================================================
    // EXERCISE 3: LogExecutionTime

    [LogExecutionTime]
    public static void FastMethod()
    {
        for (int i = 0; i < 100000; i++)
        {
            int x = i * i;
        }
    }

    [LogExecutionTime]
    public static void SlowMethod()
    {
        System.Threading.Thread.Sleep(1000);
    }


    // ============================================================
    // EXERCISE 5: RoleAllowed

    [RoleAllowed("ADMIN")]
    public static void DeleteUser()
    {
        Console.WriteLine("User deleted successfully.");
    }

    [RoleAllowed("USER")]
    public static void ViewProfile()
    {
        Console.WriteLine("Profile displayed.");
    }


    // ============================================================
    // EXERCISE 7: CacheResult

    [CacheResult]
    public static int ExpensiveCalculation(int number)
    {
        Console.WriteLine("Performing expensive calculation...");

        System.Threading.Thread.Sleep(2000);

        return number * number;
    }


    public static void Main()
    {
        Type programType = typeof(Program);

        // EXERCISE 1: RETRIEVE BUG REPORTS

        Console.WriteLine("===== BUG REPORTS =====");

        MethodInfo processMethod =
            programType.GetMethod("ProcessData");

        BugReportAttribute[] bugReports =
            processMethod
                .GetCustomAttributes<BugReportAttribute>()
                .ToArray();

        foreach (BugReportAttribute bug in bugReports)
        {
            Console.WriteLine("Bug: " + bug.Description);
        }

        // EXERCISE 2: IMPORTANT METHODS
        Console.WriteLine();
        Console.WriteLine("===== IMPORTANT METHODS =====");

        MethodInfo[] methods =
            programType.GetMethods(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly
            );

        foreach (MethodInfo method in methods)
        {
            ImportantMethodAttribute important =
                method.GetCustomAttribute<ImportantMethodAttribute>();

            if (important != null)
            {
                Console.WriteLine(
                    "Method: " + method.Name +
                    ", Level: " + important.Level
                );
            }
        }


        // EXERCISE 2: TODO TASKS

        Console.WriteLine();
        Console.WriteLine("===== TODO TASKS =====");

        foreach (MethodInfo method in methods)
        {
            TodoAttribute[] todos =
                method
                    .GetCustomAttributes<TodoAttribute>()
                    .ToArray();

            foreach (TodoAttribute todo in todos)
            {
                Console.WriteLine(
                    "Method: " + method.Name +
                    ", Task: " + todo.Task +
                    ", Assigned To: " + todo.AssignedTo +
                    ", Priority: " + todo.Priority
                );
            }
        }

        // EXERCISE 3: EXECUTION TIME
        Console.WriteLine();
        Console.WriteLine("===== EXECUTION TIME =====");

        MethodInfo fastMethod =
            programType.GetMethod("FastMethod");

        MethodInfo slowMethod =
            programType.GetMethod("SlowMethod");

        InvokeWithExecutionTime(fastMethod);
        InvokeWithExecutionTime(slowMethod);


        // EXERCISE 4: MAX LENGTH
        Console.WriteLine();
        Console.WriteLine("===== MAX LENGTH =====");

        try
        {
            User user1 = new User("Rahul");
            Console.WriteLine("Username accepted: " + user1.Username);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            User user2 = new User("ThisUsernameIsTooLong");
            Console.WriteLine("Username accepted: " + user2.Username);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }


        // EXERCISE 5: ROLE BASED ACCESS
        Console.WriteLine();
        Console.WriteLine("===== ROLE BASED ACCESS =====");

        string currentUserRole = "USER";

        MethodInfo deleteMethod =
            programType.GetMethod("DeleteUser");

        InvokeWithRoleCheck(deleteMethod, currentUserRole);

        currentUserRole = "ADMIN";

        InvokeWithRoleCheck(deleteMethod, currentUserRole);

        // EXERCISE 6: CUSTOM JSON SERIALIZATION
        Console.WriteLine();
        Console.WriteLine("===== JSON SERIALIZATION =====");

        User user = new User("John");

        string json = ConvertToJson(user);

        Console.WriteLine(json);

        // EXERCISE 7: CACHING
        Console.WriteLine();
        Console.WriteLine("===== CACHE RESULT =====");

        MethodInfo expensiveMethod =
            programType.GetMethod("ExpensiveCalculation");

        Console.WriteLine("First call:");

        object result1 =
            InvokeWithCache(expensiveMethod, 10);

        Console.WriteLine("Result: " + result1);

        Console.WriteLine();

        Console.WriteLine("Second call with same input:");

        object result2 =
            InvokeWithCache(expensiveMethod, 10);

        Console.WriteLine("Result: " + result2);

        Console.WriteLine();

        Console.WriteLine("Third call with different input:");

        object result3 =
            InvokeWithCache(expensiveMethod, 20);

        Console.WriteLine("Result: " + result3);
    }

    // EXERCISE 3 HELPER
    public static void InvokeWithExecutionTime(MethodInfo method)
    {
        LogExecutionTimeAttribute attribute =
            method.GetCustomAttribute<LogExecutionTimeAttribute>();

        if (attribute != null)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            method.Invoke(null, null);

            stopwatch.Stop();

            Console.WriteLine(
                method.Name +
                " execution time: " +
                stopwatch.ElapsedMilliseconds +
                " ms"
            );
        }
        else
        {
            method.Invoke(null, null);
        }
    }

    // EXERCISE 5 HELPER
    public static void InvokeWithRoleCheck(
        MethodInfo method,
        string currentUserRole)
    {
        RoleAllowedAttribute attribute =
            method.GetCustomAttribute<RoleAllowedAttribute>();

        if (attribute != null)
        {
            if (currentUserRole == attribute.Role)
            {
                method.Invoke(null, null);
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }
        }
        else
        {
            method.Invoke(null, null);
        }
    }

    // EXERCISE 6 HELPER
    public static string ConvertToJson(object obj)
    {
        Type type = obj.GetType();

        FieldInfo[] fields =
            type.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

        StringBuilder json = new StringBuilder();

        json.Append("{");

        bool firstField = true;

        foreach (FieldInfo field in fields)
        {
            JsonFieldAttribute attribute =
                field.GetCustomAttribute<JsonFieldAttribute>();

            if (attribute != null)
            {
                if (!firstField)
                {
                    json.Append(",");
                }

                string fieldName = attribute.Name;

                object value = field.GetValue(obj);

                json.Append("\"");
                json.Append(fieldName);
                json.Append("\":\"");

                json.Append(value);

                json.Append("\"");

                firstField = false;
            }
        }

        json.Append("}");

        return json.ToString();
    }

    // EXERCISE 7 HELPER
    static Dictionary<string, object> cache =
        new Dictionary<string, object>();

    public static object InvokeWithCache(
        MethodInfo method,
        params object[] parameters)
    {
        CacheResultAttribute attribute =
            method.GetCustomAttribute<CacheResultAttribute>();

        if (attribute == null)
        {
            return method.Invoke(null, parameters);
        }

        string key = method.Name;

        foreach (object parameter in parameters)
        {
            key += "_" + parameter;
        }

        if (cache.ContainsKey(key))
        {
            Console.WriteLine("Returning cached result...");

            return cache[key];
        }

        object result =
            method.Invoke(null, parameters);

        cache[key] = result;

        return result;
    }
}