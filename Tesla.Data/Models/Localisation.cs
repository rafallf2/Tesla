﻿namespace Tesla.Data.Models
{
    public class Localisation
    {
        public int Id { get; set; }
        public ICollection<CarLocalisation> CarLocalisation { get; set; }
        public int ReservationId { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
        public string Name { get; set; }
    }
}