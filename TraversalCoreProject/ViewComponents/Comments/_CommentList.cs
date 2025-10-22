using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Comments
{
    public class _CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly Context _context;

        public _CommentList(ICommentService commentService, Context context)
        {
            _commentService = commentService;
            _context = context;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = _context.Comments.Where(x => x.DestinationId == id).Count();
            var values = _commentService.TGetCommentListWithDestinationAndUser(id);
            return View(values);
        }
    }
}
