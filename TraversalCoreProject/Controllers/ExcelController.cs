using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController(IExcelService _excelService) : Controller
    {

        public IActionResult Index()
        {
           return View();
        }
        public IActionResult StaticExcelReport()
        {
            _excelService.CreateStaticExcelReport();
            return File("/ExcelReports/StaticReport.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","StaticReport.xlsx");
        }

     
        public IActionResult DestinationExcelReport()
        {
            _excelService.CreateDestinationExcelReport();
            return File("/ExcelReports/DestinationReport.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","DestinationReport.xlsx");
        }
    }
}
