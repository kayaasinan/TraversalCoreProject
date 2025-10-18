using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController(Context _context) : Controller
    {

        public IActionResult Index()
        {
           return View();
        }
        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Rota";
            workSheet.Cells[1, 2].Value = "Rehber";
            workSheet.Cells[1, 3].Value = "Kontenjan";

            workSheet.Cells[2, 1].Value = "Karadeniz Turu";
            workSheet.Cells[2, 2].Value = "Semra Bulut";
            workSheet.Cells[2, 3].Value = "25";

            workSheet.Cells[3, 1].Value = "Balkan Turu";
            workSheet.Cells[3, 2].Value = "Yeşim Akıncı";
            workSheet.Cells[3, 3].Value = "40";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml", "dosya2.xlsx");
        }
        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();

            destinationModels = _context.Destinations.Select(x => new DestinationModel
            {
                Capacity = x.Capacity,
                Price = x.Price,
                City = x.City,
                DayNight = x.DayNight
            }).ToList();
            return destinationModels;
        }
        public IActionResult DestinationExcelReport()
        {
            using var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Tur Listesi");
            workSheet.Cell(1, 1).Value = "Şehir";
            workSheet.Cell(1, 1).Value = "Konaklama Süresi";
            workSheet.Cell(1, 1).Value = "Fiyat";
            workSheet.Cell(1, 1).Value = "Kapasite";

            int rowCount = 2;

            foreach (var item in DestinationList())
            {
                workSheet.Cell(rowCount, 1).Value = item.City;
                workSheet.Cell(rowCount, 2).Value = item.DayNight;
                workSheet.Cell(rowCount, 3).Value = item.Capacity;
                workSheet.Cell(rowCount, 4).Value = item.Price;
                rowCount++;
            }
            using var stream = new MemoryStream();
            workBook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml", "YeniListe.xlsx");
        }
    }
}
