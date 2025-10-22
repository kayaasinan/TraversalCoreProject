using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<CommentDto>
    {
        List<CommentDto> TGetDestinationById(int id);

        List<CommentDto> TGetCommentListWithDestination();

        List<CommentDto> TGetCommentListWithDestinationAndUser(int id);
    }
}
