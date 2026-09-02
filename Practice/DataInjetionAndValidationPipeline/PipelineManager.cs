public class PipelineManager
{
    // Covariance: More derived type is assigned to less derived type.
    public void ProcessBatch(IEnumerable<User> users, IValidator<User> validator)
    {
        List<string> failureList = new List<string>();
        foreach (User user in users)
        {
            if (!validator.Validate(user))
            {
                failureList.Add(user.Email);
            }
        }

        if (failureList.Count > 0)
        {
            throw new BatchValidationException("Batch processing aborted due to invalid data.", failureList);
        }
    }
}