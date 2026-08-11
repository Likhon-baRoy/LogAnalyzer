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
}