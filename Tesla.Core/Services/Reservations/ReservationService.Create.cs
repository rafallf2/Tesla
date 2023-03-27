using Tesla.Data.Dto;
using Tesla.Data.Models;

namespace Tesla.Core.Services.Reservations
{
    public partial class ReservationService
    {
        public void Create(ReservationCreateDto reservationCreateDto)
        {
            var clientId = _reservationsRepository.CreateClient(new Client
            {
                Email = reservationCreateDto.Email,
                FirstName = reservationCreateDto.FirstName,
                LastName = reservationCreateDto.LastName,
                Phone = reservationCreateDto.Phone
            });
            _reservationsRepository.CreateReservation(new Reservation
            {
                CarId = reservationCreateDto.CarId,
                LocalisationId = reservationCreateDto.LocalisationId,
                ClientId = clientId,
                DateFrom = reservationCreateDto.DateFrom,
                DateTo = reservationCreateDto.DateTo,
                TotalCost = _reservationsRepository.GetTotalCost(new GetTotalCost
                {
                    CarId = reservationCreateDto.CarId,
                    DateFrom = reservationCreateDto.DateFrom,
                    DateTo = reservationCreateDto.DateTo
                })
            });
        }
    }
}
