namespace LogAnalyzer.Models;

public sealed class LogEntry
{
    public DateTime Timestamp { get; set; }
    public string Method { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public int TimeTakenMs { get; set; }
    public string ClientIp { get; set; } = string.Empty;
}