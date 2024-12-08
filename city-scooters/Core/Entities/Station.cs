namespace city_scooters.Core.Entities
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Scooter> Scooters { get; set; }

    }
}
