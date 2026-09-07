using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

class ObjectAttributeValidator<T> : IAttributeValidator
{
    public T Obj { get; }
    public ObjectAttributeValidator(T obj)
    {
        Obj = obj;
    }
    public void ValidateObjectAttribute()
    {
        // Validate using reflection, not with built-in validator
        Type objectType = typeof(T);

        //object[] objectAttributes = objectType.GetCustomAttributes(typeof(RegularExpressionAttribute), typeof(RequiredAttribute),false); // not the way since you cannot take 
        
        PropertyInfo[] props = objectType.GetProperties();

        foreach(var prop in props)
        {
            object value = prop.GetValue(Obj);
            Console.WriteLine(value);
            var validationAttributes = prop.GetCustomAttributes(false).OfType<ValidationAttribute>();
            foreach(var att in validationAttributes)
            {
                var context = new ValidationContext(Obj) { MemberName = prop.Name };
                ValidationResult result = att.GetValidationResult(value, context);

                if (result != ValidationResult.Success)
                {
                    //errors.Add(result.ErrorMessage);
                    Console.WriteLine(result.ErrorMessage);
                }
            }
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        DateTime dob = new DateTime(1995, 8, 15);
        User user1 = new User("sayan", "sayan@mail.com", dob);
        ObjectAttributeValidator<User> validator = new ObjectAttributeValidator<User>(user1);
        validator.ValidateObjectAttribute();
    }
}