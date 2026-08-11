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

    public IEnumerable<StatusCodeReport> GetStatusCodeReport(IEnumerable<LogEntry> logs)
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
                .Take(count)
                .Select(log => new SlowApiReport
                {
                    Url = log.Url,
                    Method = log.Method,
                    StatusCode = log.StatusCode,
                    TimeTakenMs = log.TimeTakenMs
                });
    }

    public IEnumerable<TopRequestedApiReport> GetTopRequestedApis(IEnumerable<LogEntry> logs, int count = 10)
    {
        return logs
                .GroupBy(log => new
                {
                    log.Url,
                    log.Method
                })
                .Select(group => new TopRequestedApiReport
                {
                    Url = group.Key.Url,
                    Method = group.Key.Method,
                    HitCount = group.Count()
                })
                .OrderByDescending(report => report.HitCount)
                .Take(count);
    }

    public IEnumerable<ErrorApiReport> GetTopErrorApis(IEnumerable<LogEntry> logs, int count = 10)
    {
        return logs
                .Where(log => log.StatusCode >= 400)
                .GroupBy(log => new
                {
                    log.Url,
                    log.Method,
                    log.StatusCode
                })
                .Select(group => new ErrorApiReport
                {
                    Url = group.Key.Url,
                    Method = group.Key.Method,
                    StatusCode = group.Key.StatusCode,
                    HitCount = group.Count()
                })
                .OrderByDescending(report => report.HitCount)
                .Take(count);
    }
}