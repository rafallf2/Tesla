using Tesla.Data.Database;

namespace Tesla.Data
{
    public class Seeder : ISeeder
    {
        private readonly TeslaDbContext _database;
        public Seeder(TeslaDbContext database)
        {
            _database = database;
        }
        public void Init()
        {
            AddCars();
            AddLocalisation();
        }
        private void AddCars()
        {
            if (!_database.Cars.Any())
            {
                _database.Cars.Add(new Models.Car
                {
                    Name = "Tesla S",
                    CostPerDay = 600
                });
                _database.Cars.Add(new Models.Car
                {
                    Name = "Tesla Y",
                    CostPerDay = 610
                });
                _database.Cars.Add(new Models.Car
                {
                    Name = "Tesla X",
                    CostPerDay = 650
                });
                _database.Cars.Add(new Models.Car
                {
                    Name = "Tesla 3",
                    CostPerDay = 690
                });
            }
            _database.SaveChanges();
        }
        private void AddLocalisation()
        {
            if (!_database.Localisations.Any())
            {
                _database.Localisations.Add(new Models.Localisation
                {
                    Name = "Mallorca",
                });
                _database.Localisations.Add(new Models.Localisation
                {
                    Name = "Palma Airport",
                });
                _database.Localisations.Add(new Models.Localisation
                {
                    Name = "Palma City Center",
                });
                _database.Localisations.Add(new Models.Localisation
                {
                    Name = "Alcudia",
                });
                _database.Localisations.Add(new Models.Localisation
                {
                    Name = "Manacor",
                });
                _database.SaveChanges();
            }
        }
    }
}