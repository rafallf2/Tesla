using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public interface IReservationsRepository
    {
        int CreateClient(Client model);
        void CreateReservation(Reservation model);
        double GetTotalCost(GetTotalCost model);
    }
}