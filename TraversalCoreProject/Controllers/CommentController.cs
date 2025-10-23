using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {

            _commentService = commentService;
            _userManager = userManager;
        }

        public PartialViewResult AddComment(int id)
        {
            //ViewBag.destId = id;
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
