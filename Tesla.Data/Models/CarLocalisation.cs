namespace Tesla.Data.Models
{
    public class CarLocalisation
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int LocalisationId { get; set; }
        public Localisation Localisation { get; set; }
    }
}
