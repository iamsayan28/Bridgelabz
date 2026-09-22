using System;
using System.ComponentModel.DataAnnotations;
public class NotFutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
            return date <= DateTime.Today;
        return false;
    }
}

public class AllowedValuesAttribute : ValidationAttribute
{
    private readonly string[] _allowed;
    public AllowedValuesAttribute(params string[] allowed) => _allowed = allowed;

    public override bool IsValid(object value)
    {
        return value != null && _allowed.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
    }
}