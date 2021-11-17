using System.Collections.Generic;
using System.Threading.Tasks;
using Core.StorageManagers.Interfaces;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Core.StorageManagers
{
    public class UsersStorageManager : IUsersStorageManager
    {
        private readonly IUnitOfWork _uow;

        public UsersStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<IReadOnlyList<User>> GetAllAsync()
            => await _uow.UsersRepository.GetAllAsync();

        public async Task<IReadOnlyList<User>> GetByIdsAsync(IEnumerable<long> ids) 
            => await _uow.UsersRepository.GetByIdsAsync(ids);

        public async Task<User> GetByIdAsync(long id)
            => await _uow.UsersRepository.GetByIdAsync(id);

        public async Task<int> CreateAsync(User user)
        {
            var result = await _uow.UsersRepository.CreateAsync(user);
            _uow.Commit();
            return result;
        }

        public async Task<int> UpdateAsync(User user)
        {
            var result = await _uow.UsersRepository.UpdateAsync(user);
            _uow.Commit(); 
            return result;
        }

        public async Task<int> DeleteAsync(long id)
        {
            var result = await _uow.UsersRepository.DeleteAsync(id);
            _uow.Commit();
            return result;
        }
    }
}