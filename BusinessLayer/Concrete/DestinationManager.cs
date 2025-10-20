using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.DestinationDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
