using System.Text.RegularExpressions;

public class UserValidator : BaseValidator<User>
{
    // _rules : List where each element inside is a "Function Delegate Type" taking a method that takes input User object and Output boolean (A regex expression)
    private List<Func<User, bool>> _rules = new List<Func<User, bool>>();
    private Action<string> logger;
    public UserValidator(Action<string> logger)
    {
        this.logger = logger;
        
        // Embarrasing error before ;( -> write correct patterns expressions!
        _rules.Add(user => Regex.IsMatch(user.Email, @"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$"));

        _rules.Add(user => Regex.IsMatch(user.PhoneNumber, @"^[0-9]{10}$"));
    }

    public override bool CheckRules(User item)
    {
        // Match rules against each User object by looping through each rule
        foreach (Func<User, bool> rule in _rules)
        {
            if (!rule(item))
            {
                logger($"Validation failed for User:{item.Email}");
                return false;
            }
        }
        return true;
    }
}
