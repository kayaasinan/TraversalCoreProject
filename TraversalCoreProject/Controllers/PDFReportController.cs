using DataAccessLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class PDFReportController(Context _context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/file1.pdf");
            using var stream = new FileStream(path, FileMode.Create);

            using var document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Statik Pdf Raporu");

            document.Add(paragraph);

            document.Close();

            return File("/PDFReports/file1.pdf", "application/pdf", "file1.pdf");
        }
        public List<ReservationModel> ReservationList()
        {
            return _context.Reservations.Include(x => x.AppUser).Include(x => x.Destination).Select(x => new ReservationModel
            {
                Name = x.AppUser.Name + " " + x.AppUser.SurName,
                Destination = x.Destination.City,
                PeopleCount = x.NumberOfPeople,
                ReservationDate = x.ReservationDate
            }).ToList();
        }
        public IActionResult DynamicReservationReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/reservation_report.pdf");

            using (var stream = new FileStream(path, FileMode.Create))
            using (var document = new Document(PageSize.A4))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;

                table.AddCell("Ad Soyad");
                table.AddCell("Rota");
                table.AddCell("Kişi Sayısı");
                table.AddCell("Rezervasyon Tarihi");

                var reservations = ReservationList();
                foreach (var item in reservations)
                {
                    table.AddCell(item.Name);
                    table.AddCell(item.Destination);
                    table.AddCell(item.PeopleCount.ToString());
                    table.AddCell(item.ReservationDate.ToString("dd.MM.yyyy"));
                }

                document.Add(table);
            }

            return File("/pdfreports/reservation_report.pdf", "application/pdf", "RezervasyonRaporu.pdf");
        }
    }
}
