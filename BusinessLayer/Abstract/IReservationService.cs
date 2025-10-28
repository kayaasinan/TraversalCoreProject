using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<ReservationDto>
    {
        List<ReservationDto> TGetListWithReservationByWaitApproval(int id);
        List<ReservationDto> TGetListWithReservationByPrevious(int id);
        List<ReservationDto> TGetListWithReservationByAccepted(int id);
        List<ReservationDto> TGetCanceledReservationsByAdmin(int id);
        public List<ReservationDto> TGetAllReservationsWithDetails();
        public void TChangeReservationStatus(int id, ReservationStatus newStatus);
    }
}
