using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public partial class ReservationsRepository
    {
        public double GetTotalCost(GetTotalCost model)
        {
            var car = _database.Cars.FirstOrDefault(c => c.Id == model.CarId);
            if (car == null) throw new Exception("Car not found!");
            var days = (model.DateTo.Date - model.DateFrom.Date).TotalDays+1;
            return days * car.CostPerDay;
        }
    }
}
