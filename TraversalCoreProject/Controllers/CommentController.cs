using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger _logger;
        CommentManager commentManager = new CommentManager(new EfCommentDal());
 
        public CommentController(ILogger logger)
        {
            _logger = logger;
        }
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;

            _logger.LogInformation("comment eklendı");

            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}
