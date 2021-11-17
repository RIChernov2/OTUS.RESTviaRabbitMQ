using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Manager.Repositories.Interfaces
{
    public interface IGenericRepository<T, in TArg> where T : class
    {
        Task<T> GetByIdAsync(TArg id);
        Task<IReadOnlyList<T>> GetByIdsAsync(IEnumerable<TArg> ids);
        Task <IReadOnlyList<T>> GetAllAsync();
        Task<int> CreateAsync(T entity);
        Task<int> UpdateByUserSearchAsync(T entity);
        Task<int> DeleteAsync(TArg id);
    }
}