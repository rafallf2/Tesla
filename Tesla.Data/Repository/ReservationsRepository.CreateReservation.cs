using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public partial class ReservationsRepository
    {
        public void CreateReservation(Reservation model) {
            _database.Reservations.Add(model);
            _database.SaveChanges();
        }
    }
}