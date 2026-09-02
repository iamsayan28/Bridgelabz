public interface IValidator<T>
{
    bool Validate(T item); // Function that applies rules to each item(user's mail and ph no.) and counts no of items processed
}