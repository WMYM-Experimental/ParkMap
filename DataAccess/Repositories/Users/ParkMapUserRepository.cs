using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using ParkMap.Areas.Identity.Data;

namespace ParkMap.DataAccess.Repositories
{
    public class ParkMapUserRepository : Repo<ParkMapUser>, IParkMapUserRepository
    {
        public ParkMapUserRepository(ParkMapContext context) : base(context)
        {
        }

        public async Task CreateUser(ParkMapUser user) => await CreateAsync(user);

        public async Task<IEnumerable<ParkMapUser>> GetAllUsers(bool trackChanges)
            => await FindAllAsync(trackChanges).Result.OrderBy(user => user.Email).ToListAsync();

        public async Task<ParkMapUser?> GetUser(string email, bool trackChanges)
            => await FindByConditionAsync(user => user.Email.Equals(email), trackChanges).Result.SingleOrDefaultAsync();

        public async Task UpdateUser(ParkMapUser user) => await UpdateAsync(user);

        public Task DeleteUser(ParkMapUser user) => DeleteAsync(user);
    }
}
