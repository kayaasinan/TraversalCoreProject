using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.DestinationDTOs;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;
        private readonly IMapper _mapper;

        public DestinationManager(IDestinationDal destinationDal, IMapper mapper)
        {
            _destinationDal = destinationDal;
            _mapper = mapper;
        }

        public void TAdd(DestinationDto dto)
        {
            var entity = _mapper.Map<Destination>(dto);
            _destinationDal.Insert(entity);
        }

        public void TDelete(DestinationDto dto)
        {
            var entity = _mapper.Map<Destination>(dto);
            _destinationDal.Delete(entity);
        }

        public void TUpdate(DestinationDto dto)
        {
            var entity = _mapper.Map<Destination>(dto);
            _destinationDal.Update(entity);
        }

        public List<DestinationDto> TGetList()
        {
            var entities = _destinationDal.GetList();
            return _mapper.Map<List<DestinationDto>>(entities);
        }

        public DestinationDto TGetById(int id)
        {
            var entity = _destinationDal.GetById(id);
            return _mapper.Map<DestinationDto>(entity);
        }

        public DestinationDto TGetDestinationWithGuide(int id)
        {
            var entities = _destinationDal.GetDestinationWithGuide(id);
            return _mapper.Map<DestinationDto>(entities);
        }

        public List<DestinationDto> TGetLast4Destination()
        {
            var entities= _destinationDal.GetLast4Destination();
            return _mapper.Map<List<DestinationDto>>(entities);
        }
    }
}
