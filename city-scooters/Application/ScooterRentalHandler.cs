using city_scooters.Core.Interfaces;

namespace city_scooters.Application
{
    public class RentScooterHandler
    {
        private readonly IStationRepository _stationRepository;

        public RentScooterHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<bool> HandleAsync(int scooterId, string userDni)
        {
            // Business rule: Check for scooter availability and process the rental
            return await _stationRepository.RentScooterAsync(scooterId, userDni);
        }
    }
}
