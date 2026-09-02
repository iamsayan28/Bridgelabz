public class BatchValidationException : Exception
{
    public List<string> FailedRecords { get; }
    public BatchValidationException(string message, List<string> failedRecords) : base(message)
    {
        FailedRecords = failedRecords;
    }
}