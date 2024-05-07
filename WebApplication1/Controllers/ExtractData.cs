using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExtractData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcelController : ControllerBase
    {
        [HttpGet("extract")]
        public IActionResult ExtractData()
        {
            // تمكين الترخيص للاستخدام غير التجاري
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // تحديد مسار ملف Excel المراد قراءته باستخدام المسار المطلق الذي ذكرته
            string filePath = "/Users/al-noor/Downloads/data.xlsx";

            // التحقق من وجود الملف
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound($"File '{filePath}' not found.");
            }

            // إنشاء قائمة لتمثيل البيانات التي سيتم إرجاعها
            var dataList = new List<Dictionary<string, string>>();

            // فتح الملف وقراءة محتوياته
            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int totalRows = worksheet.Dimension.Rows;
                int totalCols = worksheet.Dimension.Columns;

                // جمع عناوين الأعمدة
                var headers = new List<string>();
                for (int col = 1; col <= totalCols; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Text);
                }

                // قراءة باقي الصفوف
                for (int row = 2; row <= totalRows; row++)
                {
                    var rowDict = new Dictionary<string, string>();
                    for (int col = 1; col <= totalCols; col++)
                    {
                        rowDict[headers[col - 1]] = worksheet.Cells[row, col].Text;
                    }
                    dataList.Add(rowDict);
                }
            }

            return Ok(dataList);
        }
    }
}
