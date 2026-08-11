using ClosedXML.Excel;

namespace LogAnalyzer.Services;

public sealed class ExcelReportGenerator
{
    public void GenerateReport()
    {
        var workbook = new XLWorkbook();

        var sheet = workbook.Worksheets.Add("Summary");

        sheet.Cell("A1").Value = "Hello";
        sheet.Cell("B1").Value = "World";

        workbook.SaveAs("LogReport.xlsx");

        Console.WriteLine("Excel Generated Successfully.");
    }
}