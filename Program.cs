using LogAnalyzer.Services;

var parser = new LogParser();
var reportService = new ReportService();

var logs = parser.ParseFile("sample.log");

Console.WriteLine($"Average RTT: {reportService.GetAverageResponseTime(logs):F2} ms");
Console.WriteLine($"Total Hits: {reportService.GetTotalHitCount(logs)}");
Console.WriteLine($"Successful Requests: {reportService.GetSuccessRequestCount(logs)}");

var statusCodeReport = reportService.GetStatusCodeReport(logs);
Console.WriteLine();
Console.WriteLine("Status Code Report");
Console.WriteLine("---------------------------");
Console.WriteLine($"{"Status",-12} {"Count",5}");
Console.WriteLine("---------------------------");

foreach (var report in statusCodeReport)
{
    Console.WriteLine($"{report.StatusCode,-12} {report.Count,5}");
}