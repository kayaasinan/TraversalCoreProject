using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;
        private readonly IMapper _mapper;

        public ReservationManager(IReservationDal reservationDal, IMapper mapper)
        {
            _reservationDal = reservationDal;
            _mapper = mapper;
        }

        public void TAdd(ReservationDto dto)
        {
            var entity = _mapper.Map<Reservation>(dto);
            _reservationDal.Insert(entity);
        }

        public void TDelete(ReservationDto dto)
        {
            var entity = _mapper.Map<Reservation>(dto);
            _reservationDal.Delete(entity);
        }

        public void TUpdate(ReservationDto dto)
        {
            var entity = _mapper.Map<Reservation>(dto);
            _reservationDal.Update(entity);
        }

        public List<ReservationDto> TGetList()
        {
            var entities = _reservationDal.GetList();
            return _mapper.Map<List<ReservationDto>>(entities);
        }

        public ReservationDto TGetById(int id)
        {
            var entity = _reservationDal.GetById(id);
            return _mapper.Map<ReservationDto>(entity);
        }

        public List<ReservationDto> TGetListWithReservationByAccepted(int id)
        {
            var entities = _reservationDal.GetListWithReservationByAccepted(id);
            return _mapper.Map<List<ReservationDto>>(entities);
        }

        public List<ReservationDto> TGetListWithReservationByPrevious(int id)
        {
            var entities = _reservationDal.GetListWithReservationByPrevious(id);
            return _mapper.Map<List<ReservationDto>>(entities);
        }

        public List<ReservationDto> TGetListWithReservationByWaitApproval(int id)
        {
            var entities = _reservationDal.GetListWithReservationByWaitApproval(id);
            return _mapper.Map<List<ReservationDto>>(entities);
        }



        //public List<Reservation> TGetListWithReservationByAccepted(int id)
        //{
        //    return _reservationDal.GetListWithReservationByAccepted(id);
        //}

        //public List<Reservation> TGetListWithReservationByPrevious(int id)
        //{
        //    return _reservationDal.GetListWithReservationByPrevious(id);
        //}

        //public List<Reservation> TGetListWithReservationByWaitApproval(int id)
        //{
        //    return _reservationDal.GetListWithReservationByWaitApproval(id);
        //}

        //public void TAdd(Reservation t)
        //{
        //    _reservationDal.Insert(t);
        //}

        //public void TDelete(Reservation t)
        //{
        //    throw new NotImplementedException();
        //}

        //public Reservation TGetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Reservation> TGetList()
        //{
        //    throw new NotImplementedException();
        //}

        //public void TUpdate(Reservation t)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
