using System.IO.Compression;
using System.IO.Pipelines;
using static System.Net.Mime.MediaTypeNames;

using StreamWriter writer = new StreamWriter(@"C:\dev\dotnet\bridgelabz\LogAnalyzerStreams\analysis.txt");
writer.WriteLine("ANALYSIS");


// COMPRESS FILE
using FileStream ogFs = File.Open("application.log", FileMode.Open);
using FileStream compressedFs = File.Create(@"C:\dev\dotnet\bridgelabz\LogAnalyzerStreams\application.log.gz");
using (GZipStream compressor = new GZipStream(compressedFs, CompressionMode.Compress))
{
    await ogFs.CopyToAsync(compressor);
} // needed to lose the resources of compress

Console.WriteLine(new FileInfo(@"C:\dev\dotnet\bridgelabz\LogAnalyzerStreams\application.log.gz").Length);
Console.WriteLine(new FileInfo("application.log").Length);
// DECOMPRESS FILE
using FileStream fs = File.Open(@"C:\dev\dotnet\bridgelabz\LogAnalyzerStreams\application.log.gz", FileMode.Open);
using var decompressor = new GZipStream(fs, CompressionMode.Decompress);
using StreamReader reader = new StreamReader(decompressor);

string keyword = "Database"; // user 
int errorCount = 0, warningCount = 0, infoCount = 0;
 
Task<string?> readTask = reader.ReadLineAsync();

//Console.WriteLine("hellloo async testing");

string? logEachLine = await readTask;
while(logEachLine != null)
{
    if (logEachLine.Contains(keyword))
    {

        await writer.WriteLineAsync(logEachLine);
    }

    if (logEachLine.Contains("ERROR"))
    {
        errorCount++;
    }
    else if (logEachLine.Contains("INFO"))
    {
        infoCount++;
    }
    else
    {
        warningCount++;
    }
    
    logEachLine = await reader.ReadLineAsync();
}

await writer.WriteAsync("\nReport");
await writer.WriteAsync($"Error Count: {errorCount} \nInfo Count: {infoCount} \nWarning Count: {warningCount}\nTotal Count = {errorCount + infoCount + warningCount}");
Console.WriteLine($"Error Count: {errorCount} \nInfo Count: {infoCount} \nWarning Count: {warningCount}\nTotal Count = {errorCount + infoCount + warningCount}");