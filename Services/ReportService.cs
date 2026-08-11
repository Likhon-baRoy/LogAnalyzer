using LogAnalyzer.Models;

namespace LogAnalyzer.Services;

public sealed class ReportService
{
    public int GetTotalHitCount(IEnumerable<LogEntry> logs)
    {
        return logs.Count();
    }
}