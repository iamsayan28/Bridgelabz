// User : An object(User Data) that our pipeline that passes through our pipeline.
public class User
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public User(string email, string phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }
}