using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public partial class ReservationsRepository
    {
        public int CreateClient(Client model)
        {
            var client = _database.Clients.FirstOrDefault(c => c.Email == model.Email && c.Phone == model.Phone && c.FirstName == model.FirstName && c.LastName == model.LastName);
            if (client != null)
            {
                return client.Id;
            }
            _database.Clients.Add(model);
            _database.SaveChanges();
            return model.Id;
        }
    }
}
