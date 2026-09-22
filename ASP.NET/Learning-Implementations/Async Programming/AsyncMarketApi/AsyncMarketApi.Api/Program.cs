//Simulate an API endpoint that fetches data from a database or external service sequentially using Task.Delay
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Logging.AddConsole();        // Add console logger (shows logs in terminal)


// notes: handler(resp for handling this get request at this endpoint)
// and this handling is an async operation itself ~ non blocking ~ when it reaches await ->
// check task done? 1. yes then synchronously continue 2. returns a task object to its caller and so it continues to the later code and when finished, a callback to call later
app.MapGet("/stocks", async() =>
{
    // this is an async end-point

    var stocks = await FetchFromExchangeAsync("NSE", );
});


static async Task<string> FetchFromExchangeAsync(string exchange, int delayMs, CancellationToken ct = default)
{
    // Task.Delay simulates waiting for a network response (I/O operation) without blocking the thread
    await Task.Delay(delayMs, ct);

    // Returns simulated stock quote data
    return $"{exchange} Quote: ₹{Random.Shared.Next(100, 500)}.00";
}