namespace LogAnalyzer.DTOs;

public sealed class LogAnalysisReport
{
    public int TotalHits { get; set; }

    public double AverageRtt { get; set; }

    public IEnumerable<StatusCodeReport> StatusCodes { get; set; }
        = Enumerable.Empty<StatusCodeReport>();

    public IEnumerable<SlowApiReport> TopSlowApis { get; set; }
        = Enumerable.Empty<SlowApiReport>();

    public IEnumerable<TopRequestedApiReport> TopRequestedApis { get; set; }
        = Enumerable.Empty<TopRequestedApiReport>();

    public IEnumerable<ErrorApiReport> TopErrorApis { get; set; }
        = Enumerable.Empty<ErrorApiReport>();

    public IEnumerable<MethodDistributionReport> MethodDistribution { get; set; }
        = Enumerable.Empty<MethodDistributionReport>();

    public IEnumerable<HourlyTrafficReport> HourlyTraffic { get; set; }
        = Enumerable.Empty<HourlyTrafficReport>();

    public IEnumerable<SlowApiReport> SlowRequests { get; set; }
        = Enumerable.Empty<SlowApiReport>();
}