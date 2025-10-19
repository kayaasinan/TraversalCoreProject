using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class PDFReportController(IPdfService _pdfService) : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            _pdfService.CreateStaticPdfReport();
            return File("/PDFReports/file1.pdf", "application/pdf", "file1.pdf");
        }
    
        public IActionResult DynamicReservationReport()
        {
            _pdfService.CreateDynamicReservationReport();
            return File("/PDFReports/reservation_report.pdf", "application/pdf", "RezervasyonRaporu.pdf");
        }
    }
}
