namespace Tesla.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
