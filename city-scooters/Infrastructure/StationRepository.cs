using city_scooters.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace city_scooters.Infrastructure;

public class StationRepository
{
    private readonly ApplicationDbContext _context;

    public StationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Scooter>> GetAvailableScootersAsync(int stationId)
    {
        return await _context.Scooters
            .Where(s => s.StationId == stationId && s.State == State.Available)
            .ToListAsync();
    }

    public async Task<bool> RentScooterAsync(int scooterId, string userDni)
    {
        var scooter = await _context.Scooters.FindAsync(scooterId);
        if (scooter == null || !(scooter.State == State.Available)) return false;

        // Additional rental record logic here
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ReturnScooterAsync(int scooterId, int stationId)
    {
        var scooter = await _context.Scooters.FindAsync(scooterId);
        if (scooter == null) return false;

        bool result = scooter.State == State.Available ? false : true;
        scooter.StationId = stationId;
        await _context.SaveChangesAsync();
        return true;
    }
}