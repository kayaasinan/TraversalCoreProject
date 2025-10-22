using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.CommentDTOs;
using Comment = EntityLayer.Concrete.Comment;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
         private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }

        public void TAdd(CommentDto dto)
        {
            var entity = _mapper.Map<Comment>(dto);
            _commentDal.Insert(entity);
        }

        public void TDelete(CommentDto dto)
        {
            var entity = _mapper.Map<Comment>(dto);
            _commentDal.Delete(entity);
        }

        public void TUpdate(CommentDto dto)
        {
            var entity = _mapper.Map<Comment>(dto);
            _commentDal.Update(entity);
        }

        public List<CommentDto> TGetList()
        {
            var entities = _commentDal.GetList();
            return _mapper.Map<List<CommentDto>>(entities);
        }

        public CommentDto TGetById(int id)
        {
            var entity = _commentDal.GetById(id);
            return _mapper.Map<CommentDto>(entity);
        }

        public List<CommentDto> TGetCommentListWithDestination()
        {
            var entities = _commentDal.GetCommentListWithDestination();
            return _mapper.Map<List<CommentDto>>(entities);

        }

        public List<CommentDto> TGetDestinationById(int id)
        {
            var entity= _commentDal.GetListByFilter(x => x.DestinationId == id);
            return _mapper.Map<List<CommentDto>>(entity);
        }

        public List<CommentDto> TGetCommentListWithDestinationAndUser(int id)
        {
            var entities = _commentDal.GetCommentListWithDestinationAndUser(id);
            return _mapper.Map<List<CommentDto>>(entities);
        }


        //public List<Comment> TGetCommentListWithDestination()
        //{
        //    return _commentDal.GetCommentListWithDestination();
        //}

        //public void TAdd(Comment t)
        //{
        //    _commentDal.Insert(t);
        //}

        //public void TDelete(Comment t)
        //{
        //    _commentDal.Delete(t);
        //}

        //public Comment TGetById(int id)
        //{
        //  return  _commentDal.GetById(id);
        //}

        //public List<Comment> TGetDestinationById(int id)
        //{
        //    return _commentDal.GetListByFilter(x => x.DestinationId == id);
        //}

        //public List<Comment> TGetList()
        //{
        //    return _commentDal.GetList();
        //}

        //public void TUpdate(Comment t)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
