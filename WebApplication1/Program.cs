using System;
using System.IO;
using OfficeOpenXml;

namespace WebApplication1
{
    class Program
    {
        static void Main()
        {
            // تمكين الترخيص للاستخدام غير التجاري
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // تحديد مسار الملف
            string filePath = "DataExcel.xlsx";
            
            // إنشاء ملف Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // إضافة ورقة عمل جديدة وتسميتها
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // كتابة بعض البيانات في الصف الأول
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Age";
                worksheet.Cells[2, 1].Value = "Amaar";
                worksheet.Cells[2, 2].Value = 30;

                // حفظ الملف إلى الموقع المحدد
                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);
            }

            Console.WriteLine($"Excel file '{filePath}' has been created.");
        }
    }
}