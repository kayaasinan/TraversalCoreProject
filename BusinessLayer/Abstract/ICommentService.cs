using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<CommentDto>
    {
        List<Comment> TGetDestinationById(int id);

        List<Comment> TGetCommentListWithDestination();
    }
}
