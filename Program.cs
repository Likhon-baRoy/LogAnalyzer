using LogAnalyzer.Services;

var parser = new LogParser();

var reportService = new ReportService();

/* Read from Single Line
var log = "2026-08-09 23:59:00 172.19.191.66 GET /SfaAppApi/api/v9/dashboard/GetTodayHighlights HTTP/1.1 443 - 43.245.120.45 - - 200 - - 598";

var result = parser.ParseLine(log);

Console.WriteLine(result?.Url);
Console.WriteLine(result?.StatusCode);
Console.WriteLine(result?.TimeTakenMs);
*/

var logs = parser.ParseFile("sample.log");

var totalHits = reportService.GetTotalHitCount(logs);
Console.WriteLine($"Total Hits: {totalHits}");

var totalSuccessHits = reportService.GetSuccessRequestCount(logs);
Console.WriteLine($"Total Success Request Count: {totalSuccessHits}");
