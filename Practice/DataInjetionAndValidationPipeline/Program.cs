class Program
{
    public static void Main(string[] args)
    {


        List<User> usersList = new List<User>() {
            new User("iamsayan@mail.com", "8240223384"),
            new User("sagar@mail.in", "9007011732"),
            new User("yo-@mail.in", "89070117%^")
        };

        // Validate each the list of users:
        // Global logger leveraging Contravariance
        Action<object> globalLogger = obj => Console.WriteLine(obj.ToString());
        UserValidator validator = new UserValidator(globalLogger);

        // Define the pipeline its going to use
        PipelineManager pipeline = new PipelineManager();

        try {
            Console.WriteLine("Starting batch processing...\n");
            pipeline.ProcessBatch(usersList, validator);
            Console.WriteLine("Batch processing completed successfully!");
        }
        catch(BatchValidationException e)
        {
            Console.WriteLine($"[ERROR]:{ e.Message}");
            foreach(var user in e.FailedRecords)
            {
                Console.WriteLine($"- {user}");
            }
        }
    }
}