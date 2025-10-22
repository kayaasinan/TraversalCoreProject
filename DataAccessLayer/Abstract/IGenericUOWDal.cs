namespace DataAccessLayer.Abstract
{
    public interface IGenericUOWDal<T>
    {
        void Insert(T t);
        void Update(T t);
        void MultiUpdate(List<T> t);
        T GetById(int id);
        List<T> GetAll();
    }
}
