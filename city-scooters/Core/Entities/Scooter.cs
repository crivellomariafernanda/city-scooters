namespace city_scooters.Core.Entities
{
    public enum State
    {
        Available, Busy, NotAvailable
    }
    public class Scooter
    {
        public int Id { get; set; }
        public State State { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
    }

}
