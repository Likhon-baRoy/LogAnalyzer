using LogAnalyzer.Models;

namespace LogAnalyzer.Services;

public sealed class LogParser
{
    public LogEntry? ParseLine(string line)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LogEntry> ParseFile(string filePath)
    {
        throw new NotImplementedException();
    }
}