using System.ComponentModel.DataAnnotations;

class User
{
    [Required]
    public string Name{ get; set; }
    [Range(18,65)]
    public int Age{ get; set; }
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User("sayan", 3);
    }
}
