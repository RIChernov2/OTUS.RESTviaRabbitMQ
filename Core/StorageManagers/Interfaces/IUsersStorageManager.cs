using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Core.StorageManagers.Interfaces
{
    public interface IUsersStorageManager
    {
        public Task<IReadOnlyList<User>> GetAllAsync();
        public Task<IReadOnlyList<User>> GetByIdsAsync(IEnumerable<long> ids);
        public Task<User> GetByIdAsync(long id);
        public Task<int> CreateAsync(User user);
        public Task<int> UpdateAsync(User user);
        public Task<int> DeleteAsync(long id);
    }
}