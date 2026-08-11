using LogAnalyzer.DTOs;
using LogAnalyzer.Models;

namespace LogAnalyzer.Services;

public sealed class ReportService
{
    public int GetTotalHitCount(IEnumerable<LogEntry> logs)
    {
        return logs.Count();
    }

    public int GetSuccessRequestCount(IEnumerable<LogEntry> logs)
    {
        return logs
                .Where(log => log.StatusCode == 200)
                .Count();
    }

    public IEnumerable<StatusCodeReport> GetStatusCodeReport(
    IEnumerable<LogEntry> logs)
    {
        return logs
                .GroupBy(log => log.StatusCode)
                .Select(group => new StatusCodeReport
                {
                    StatusCode = group.Key,
                    Count = group.Count()
                });
    }

    public double GetAverageResponseTime(IEnumerable<LogEntry> logs)
    {
        return logs.Average(log => log.TimeTakenMs);
    }

    public IEnumerable<SlowApiReport> GetTopSlowApis(IEnumerable<LogEntry> logs, int count = 10)
    {
        return logs
                .OrderByDescending(log => log.TimeTakenMs)
                .Take(10)
                .Select(log => new SlowApiReport
                {
                    Url = log.Url,
                    Method = log.Method,
                    StatusCode = log.StatusCode,
                    TimeTakenMs = log.TimeTakenMs
                });
    }
}