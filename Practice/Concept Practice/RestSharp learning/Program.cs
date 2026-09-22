using RestSharp;

// 1.----------------
//// server we want to talk to
//var client = new RestClient("https://jsonplaceholder.typicode.com");
//// 2. WHAT: Create a GET request for a specific endpoint
//var request = new RestRequest("/users/1", Method.Get);
//// 3. SEND: Execute the request asynchronously
//var response = await client.ExecuteAsync(request);
//// 4. CHECK & READ: Did it work? If so, read the answer!
//if (response.IsSuccessful)
//{
//    Console.WriteLine("Success!");
//    Console.WriteLine(response.Content+ "," + response.StatusCode);
//}
//else
//{
//    Console.WriteLine($"Error: {response.StatusCode}");
//}

// 2.----------------
//var client = new RestClient("https://jsonplaceholder.typicode.com");
//var request = new RestRequest("/users/1", Method.Get);
//var user = await client.GetAsync<User>(request);
//Console.WriteLine(user.Name);
//Console.WriteLine(user.Email);


var client = new RestClient("https://jsonplaceholder.typicode.com");
var request = new RestRequest("/users/1", Method.Get);
// RestSharp gets the JSON and turns it into a User object!
var user = await client.GetAsync<User>(request);
Console.WriteLine($"Name: {user.Name}");
Console.WriteLine($"Email: {user.Email}");
Console.WriteLine($"City: {user.Address.City}");

// 3.----------------
var usersRequest = new RestRequest("/users", Method.Get);
var users = await client.GetAsync<List<User>>(usersRequest);
foreach (var u in users)
{
    Console.WriteLine($"{u.Id} - {u.Name} - {u.Email}");
}

// dealing with C# nullable-property warnings -> required
class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
}

class Address
{
    public required string Street { get; set; }
    public required string Suite { get; set; }
    public required string City { get; set; }
    public required string Zipcode { get; set; }
}