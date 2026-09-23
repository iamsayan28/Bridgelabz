using System.ComponentModel.DataAnnotations;
public class EmployeeValidator
{
    public bool Validate(Employee employee, out List<string> errors)
    {
        errors = new List<string>();
        var context = new ValidationContext(employee);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            employee, context, results, validateAllProperties: true
        );

        if (!isValid)
        {
            foreach (var res in results)
            {
                errors.Add(res.ErrorMessage);
            }
        }
        return isValid;
    }
}