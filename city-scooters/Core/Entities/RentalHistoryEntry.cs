namespace city_scooters.Core.Entities
{
    public class RentalHistoryEntry
    {
        public int Id { get; set; }
        public string UserIdentifier { get; set; }

        public int ScooterId { get; set; }
        public Scooter Scooter { get; set; }

        public int PickUpStationId { get; set; }
        public Station PickUpStation { get; set; }

        public int? DropOffStationId { get; set; }
        public Station DropOffStation { get; set; }

        public DateTime RentalStartDateTime { get; set; }
        public DateTime? RentalEndDateTime { get; set; }
        public int TimeSpan { get; set; }
    }
}
