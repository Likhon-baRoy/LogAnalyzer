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

var slowApiReport = reportService.GetTopSlowApis(logs);

Console.WriteLine();
Console.WriteLine("Top 10 Slow API Requests");
Console.WriteLine(new string('-', 90));
Console.WriteLine($"{"Method",-8} {"Status",-8} {"Time (ms)",-12} URL");
Console.WriteLine(new string('-', 90));

foreach (var report in slowApiReport)
{
    Console.WriteLine($"{report.Method,-8} {report.StatusCode,-8} {report.TimeTakenMs,-12} {report.Url}");
}

var topRequestedApiReport = reportService.GetTopRequestedApis(logs);

Console.WriteLine();
Console.WriteLine("Top 10 Requested APIs");
Console.WriteLine(new string('-', 90));
Console.WriteLine($"{"Hits",-8} {"Method",-8} URL");
Console.WriteLine(new string('-', 90));

foreach (var report in topRequestedApiReport)
{
    Console.WriteLine($"{report.HitCount,-8} {report.Method,-8} {report.Url}");
}

var errorApiReport = reportService.GetTopErrorApis(logs);

Console.WriteLine();
Console.WriteLine("Top Error APIs");
Console.WriteLine(new string('-', 100));
Console.WriteLine($"{"Hits",8} {"Status",8} {"Method",-8} URL");
Console.WriteLine(new string('-', 100));

foreach (var report in errorApiReport)
{
    Console.WriteLine($"{report.HitCount,8} {report.StatusCode,8} {report.Method,-8} {report.Url}");
}