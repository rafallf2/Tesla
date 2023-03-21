namespace Tesla.Data.Models
{
    public class CarLocalisation
    {
        public int Id { get; set; }
        public ICollection<Car> Car { get; set; }
        public ICollection<Localisation> Localisation { get; set; }
        public int Availability { get; set; }
    }
}
