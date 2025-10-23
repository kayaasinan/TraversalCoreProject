using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        public Destination GetDestinationWithGuide(int id);
    }
}
