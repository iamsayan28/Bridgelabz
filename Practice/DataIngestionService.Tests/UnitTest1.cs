namespace DataIngestionService.Tests
{
    public class PipelineManagerTests
    {
        [Test]
        public void ProcessBatch_WithInvalidUser_ThrowsBatchValidationException()
        {
            // 1. Arrange (Set up the test)
            var invalidUsers = new List<User>
            {
                new User("good@email.com", "1234567890"),
                new User("bad-email", "123")
            };

            var validator = new UserValidator((msg) => { }); // actual non-test logger that is passed carries an action that print some shit to the console, here its doing nothing
            PipelineManager pipeline = new PipelineManager();

            // 2. Act & Assert the Throw
            // NUnit also uses Assert.Throws, which helpfully returns the caught exception!
            var exception = Assert.Throws<BatchValidationException>(() => pipeline.ProcessBatch(invalidUsers, validator));

            // 3. Assert the State (Using NUnit's "Constraint Model" syntax)
            // Instead of Assert.Single
            Assert.That(exception.FailedRecords, Has.Count.EqualTo(1));

            // Instead of Assert.Contains
            Assert.That(exception.FailedRecords, Does.Contain("bad-email"));
        }
    }
}
