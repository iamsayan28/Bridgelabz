using System.ComponentModel.DataAnnotations;

class User
{
    [Required]
    public string Name { get; }

    [RegularExpression(@"^[a-z0-9]+@[a-z0-9]+\.[a-z]{2,}$", ErrorMessage = "Invalid Email Format")]
    public string? Email { get; }

    public DateTime ?DateOfBirth { get; }

    public User(string name, string? email, DateTime? dateOfBirth)
    {
        Name = name;
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    public User(string name, string email) : this(name, email, null) { }
    public User(string name) : this(name, null, null) { }
}