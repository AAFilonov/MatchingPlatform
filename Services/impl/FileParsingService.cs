using Microsoft.Extensions.Logging;
using Models;
using Models.SMP;
using OfficeOpenXml;
using Services.@interface;

namespace Services.impl;

public class FileParsingService : IFileParsingService
{
    public static readonly string[] SUPPORTED_FILE_EXTENSIONS = { "xlsx" };
    public static readonly string[] SUPPORTED_PROBLEM_TYPES = { "SMP" };
    private readonly ILogger<FileParsingService> _logger;

    public FileParsingService(ILogger<FileParsingService> logger)
    {
        _logger = logger;
    }

    public object ParseTableFile(MemoryStream file, string problemCode)
    {
        //прочесть расширение и ументь преобразовать разные типы файла в ExcelPackage
        //получать параметр с типом задачи и подставлять разные парсеры
        var package = new ExcelPackage(file);
        return SmpParser.ParseMatching(package);
    }
}

public class SmpParser
{
    public static SmpMatching ParseMatching(ExcelPackage package)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var matching = new SmpMatching();

        var worksheet1 = package.Workbook.Worksheets[0];
        for (var row = 1; row < worksheet1.Dimension.End.Row; row++)
        {
            var man = ParseRow(worksheet1, row);
            matching.AddMan(man);
        }

        var worksheet2 = package.Workbook.Worksheets[1];
        for (var row = 1; row < worksheet2.Dimension.End.Row; row++)
        {
            var woman = ParseRow(worksheet2, row);
            matching.AddWoman(woman);
        }

        return matching;
    }

    private static CommonAllocated ParseRow(ExcelWorksheet worksheet, int row)
    {
        var name = (string)worksheet.Cells[row, 1].Value;
        var preferences = new List<string>();
        var i = 2;
        while (worksheet.Cells[row, i].Value != null)
        {
            preferences.Add((string)worksheet.Cells[row, i].Value);
            i++;
        }

        return new CommonAllocated(name, preferences);
    }
}