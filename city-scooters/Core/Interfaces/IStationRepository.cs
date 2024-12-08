namespace city_scooters.Core.Interfaces
{
    public interface IStationRepository
    {
        Task<bool> RentScooterAsync(int scooterId, string userDni);
        Task<bool> ReturnScooterAsync(int scooterId, int stationId);
    }
}
