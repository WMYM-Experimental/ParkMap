using ParkMap.Areas.Identity.Data;

namespace ParkMap.DataAccess.Repositories
{
    public interface IParkMapUserRepository
    {
        Task CreateUser(ParkMapUser user);
        Task<IEnumerable<ParkMapUser>> GetAllUsers(bool trackChanges);
        Task<ParkMapUser> GetUser(string email, bool trackChanges);

        Task UpdateUser(ParkMapUser user);
        Task DeleteUser(ParkMapUser user);
    }
}
