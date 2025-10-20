using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.CommentDTOs;
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
        public IActionResult AddComment(CommentDto comment)
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentState = true;
            _commentService.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
