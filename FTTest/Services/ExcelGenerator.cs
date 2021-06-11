using System.Collections.Generic;
using FTTest.Models;
using OfficeOpenXml;

namespace FTTest.Services
{
    class ExcelGenerator
    {
        public byte[] Generate(List<ReportModel> reports)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets
                .Add("Izdel Report");
            sheet.OutLineSummaryBelow = false;
            sheet.Cells["A1"].Value = "Изделие";
            sheet.Cells["B1"].Value = "Кол-во";
            sheet.Cells["C1"].Value = "Стоимость";

            int row = 2;

            foreach (var report in reports.FindAll(r => r.Level < 3))
            {
                sheet.Cells[row, 1].Value = report.Name;
                sheet.Cells[row, 1].Style.Indent = report.Level;
                sheet.Cells[row, 1].AutoFitColumns();
                sheet.Cells[row, 2].Value = report.Count;
                sheet.Cells[row, 3].Value = report.Cost;
                sheet.Row(row).OutlineLevel = report.Level;
                row++;
            }

            return package.GetAsByteArray();
        }
    }
}
