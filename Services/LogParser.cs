using LogAnalyzer.Models;

namespace LogAnalyzer.Services;

public sealed class LogParser
{
    private const int DateIndex = 0;
    private const int TimeIndex = 1;
    private const int MethodIndex = 3;
    private const int UrlIndex = 4;
    private const int ClientIpIndex = 8;
    private const int StatusCodeIndex = 11;
    private const int TimeTakenIndex = 14;
    private const int MinimumColumnCount = 15;

    public LogEntry? ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < MinimumColumnCount)
            return null;

        var timestampText = $"{parts[DateIndex]} {parts[TimeIndex]}";

        if (!DateTime.TryParse(timestampText, out var timestamp))
            return null;

        if (!int.TryParse(parts[StatusCodeIndex], out var statusCode))
            return null;

        if (!int.TryParse(parts[TimeTakenIndex], out var timeTaken))
            return null;

        return new LogEntry
        {
            Timestamp = timestamp,
            Method = parts[MethodIndex],
            Url = parts[UrlIndex],
            ClientIp = parts[ClientIpIndex],
            StatusCode = statusCode,
            TimeTakenMs = timeTaken
        };
    }

    public IEnumerable<LogEntry> ParseFile(string filePath)
    {
        throw new NotImplementedException();
    }
}