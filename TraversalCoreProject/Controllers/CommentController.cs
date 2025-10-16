using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {

            _commentService = commentService;
        }

        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;

            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            _commentService.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}
