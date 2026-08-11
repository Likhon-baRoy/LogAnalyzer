namespace LogAnalyzer.DTOs;

public sealed class MethodDistributionReport
{
    public string Method { get; set; } = string.Empty;
    public int HitCount { get; set; }
}