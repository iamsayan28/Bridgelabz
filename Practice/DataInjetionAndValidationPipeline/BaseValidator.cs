public abstract class BaseValidator<T> : IValidator<T>
{
    public int ItemsProcessed { get; protected set; }
    public abstract bool CheckRules(T item);

    public bool Validate(T item)
    {
        ItemsProcessed++;
        return CheckRules(item);
    }
}
