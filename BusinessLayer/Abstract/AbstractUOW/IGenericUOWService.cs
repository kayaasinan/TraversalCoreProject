namespace BusinessLayer.Abstract.AbstractUOW
{
    public interface IGenericUOWService<TDto>
    {
        void TInsert(TDto t);
        void TUpdate(TDto t);
        void TMultiUpdate(List<TDto> t);
        TDto TGetById(int id);
        List<TDto> TGetAll();
    }
}
