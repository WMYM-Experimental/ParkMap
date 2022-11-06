using ParkMap.Areas.Identity.Data;
using ParkMap.Models;

namespace ParkMap.DataAccess.Repositories.PkParkingLots
{
    public interface IParkingLotRepository
    {
        Task CreateParkingLog(ParkingLot pl);
        Task<IEnumerable<ParkingLot>> GetAll(bool trackChanges);
        Task<ParkingLot> GetParkingLot(int id, bool trackChanges);
        Task UpdateParkingLot(ParkingLot pl);
        Task DeleteParkingLot(ParkingLot pl);
    }
}
