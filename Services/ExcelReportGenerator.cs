using ClosedXML.Excel;
using LogAnalyzer.DTOs;

namespace LogAnalyzer.Services;

public sealed class ExcelReportGenerator
{
    public void GenerateReport(LogAnalysisReport report, string filePath)
    {
        var workbook = new XLWorkbook();

        CreateSummarySheet(workbook, report);

        CreateStatusCodeSheet(workbook, report);

        workbook.SaveAs(filePath);
    }

    private static void CreateSummarySheet(XLWorkbook workbook, LogAnalysisReport report)
    {
        var sheet = workbook.Worksheets.Add("Summary");

        sheet.Cell("A1").Value = "Metric";
        sheet.Cell("B1").Value = "Value";

        sheet.Cell("A2").Value = "Total Hits";
        sheet.Cell("B2").Value = report.TotalHits;

        sheet.Cell("A3").Value = "Average RTT";
        sheet.Cell("B3").Value = report.AverageRtt;
        sheet.Cell("B3").Style.NumberFormat.Format = "0.00";
    }

    private static void CreateStatusCodeSheet(XLWorkbook workbook, LogAnalysisReport report)
    {
        var sheet = workbook.Worksheets.Add("Status Codes");

        sheet.Cell("A1").Value = "Status Code";
        sheet.Cell("B1").Value = "Hit Count";

        int row = 2;

        foreach (var status in report.StatusCodes)
        {
            sheet.Cell(row, 1).Value = status.StatusCode;
            sheet.Cell(row, 2).Value = status.Count;

            row++;
        }
    }
}