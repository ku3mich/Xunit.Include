using Xunit.Abstractions;

namespace Xunit.Include.Tests;

public class UnitTest1(ITestOutputHelper log)
{

    [Theory]
    [StreamOfFile("files/one")]
    [StreamOfFile("files/two")]
    public async Task Test1(StreamOfFile stream)
    {
        using var streamReader = new StreamReader(stream.Content);
        var content = await streamReader.ReadToEndAsync();
        
        log.WriteLine(content);
    }
}