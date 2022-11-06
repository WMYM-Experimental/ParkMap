using Microsoft.EntityFrameworkCore;
using ParkMap.Areas.Identity.Data;
using ParkMap.Models;

namespace ParkMap.DataAccess.Repositories.PkParkingLots
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly ParkMapContext _context;

        public ParkingLotRepository(ParkMapContext context)
        {
            _context = context;
        }

        public async Task CreateParkingLog(ParkingLot pl)
        {
            await _context.ParkingLot.AddAsync(pl);
        }

        public async Task DeleteParkingLot(ParkingLot pl)
        {
            _context.ParkingLot.Remove(pl);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<ParkingLot>> GetAll(bool trackChanges)
        {
            return await _context.ParkingLot
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<ParkingLot> GetParkingLot(int id, bool trackChanges)
        {
            return await _context.ParkingLot
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task UpdateParkingLot(ParkingLot pl)
        {
            _context.ParkingLot.Update(pl);
            await Task.CompletedTask;
        }
    }
}
