namespace LogAnalyzer.DTOs;

public sealed class ErrorApiReport
{
    public string Url { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public int HitCount { get; set; }
}