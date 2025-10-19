using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class PdfManager : IPdfService
    {
        private readonly Context _context;

        public PdfManager(Context context)
        {
            _context = context;
        }
        public void CreateDynamicReservationReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/reservation_report.pdf");
            using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            using var document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);
            document.Open();

       
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;

            table.AddCell("Ad Soyad");
            table.AddCell("Rota");
            table.AddCell("Kişi Sayısı");
            table.AddCell("Rezervasyon Tarihi");

           
            var reservations = _context.Reservations.Include(x => x.AppUser).Include(x => x.Destination).Select(x => new
                {
                    FullName = x.AppUser.Name + " " + x.AppUser.SurName,
                    Destination = x.Destination.City,
                    PeopleCount = x.NumberOfPeople,
                    Date = x.ReservationDate
                }).ToList();

       
            foreach (var item in reservations)
            {
                table.AddCell(item.FullName);
                table.AddCell(item.Destination);
                table.AddCell(item.PeopleCount.ToString());
                table.AddCell(item.Date.ToString("dd.MM.yyyy"));
            }

            document.Add(table);
            document.Close();
        }

        public void CreateStaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/file1.pdf");
            using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            using var document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            document.Add(new Paragraph("Traversal Rezervasyon Statik Pdf Raporu"));
            document.Close();
        }
    }
}
