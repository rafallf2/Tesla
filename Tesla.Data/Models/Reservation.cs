namespace Tesla.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int LocalisationId { get; set; }
        public Localisation Localisation { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public double TotalCost { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
}
