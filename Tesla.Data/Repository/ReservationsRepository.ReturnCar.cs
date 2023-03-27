namespace Tesla.Data.Repository
{
    public partial class ReservationsRepository
    {
        public void ReturnCar(int reservationId)
        {
            var reservation = _database.Reservations.FirstOrDefault(x => x.Id == reservationId);
            if (reservation == null) { throw new Exception("Reservation not found!"); };
            reservation.IsReturned = true;
            _database.SaveChanges();
        }
    }
}