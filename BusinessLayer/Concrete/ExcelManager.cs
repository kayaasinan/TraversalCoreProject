using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager(Context _context) : IExcelService
    {
        public void CreateDestinationExcelReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ExcelReports/StaticReport.xlsx");

            using var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Sayfa1");

            workSheet.Cell(1, 1).Value = "Rota";
            workSheet.Cell(1, 2).Value = "Rehber";
            workSheet.Cell(1, 3).Value = "Kontenjan";

            workSheet.Cell(2, 1).Value = "Karadeniz Turu";
            workSheet.Cell(2, 2).Value = "Semra Bulut";
            workSheet.Cell(2, 3).Value = 25;

            workSheet.Cell(3, 1).Value = "Balkan Turu";
            workSheet.Cell(3, 2).Value = "Yeşim Akıncı";
            workSheet.Cell(3, 3).Value = 40;

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            workBook.SaveAs(path);
        }

        public void CreateStaticExcelReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ExcelReports/DestinationReport.xlsx");

            using var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Tur Listesi");

            workSheet.Cell(1, 1).Value = "Şehir";
            workSheet.Cell(1, 2).Value = "Konaklama Süresi";
            workSheet.Cell(1, 3).Value = "Fiyat";
            workSheet.Cell(1, 4).Value = "Kapasite";

            int row = 2;

            var destinations = _context.Destinations.Select(x => new Destination
            {
                Capacity = x.Capacity,
                Price = x.Price,
                City = x.City,
                DayNight = x.DayNight
            }).ToList();

            foreach (var item in destinations)
            {
                workSheet.Cell(row, 1).Value = item.City;
                workSheet.Cell(row, 2).Value = item.DayNight;
                workSheet.Cell(row, 3).Value = item.Price;
                workSheet.Cell(row, 4).Value = item.Capacity;
                row++;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            workBook.SaveAs(path);
        }
    }
    }
}
