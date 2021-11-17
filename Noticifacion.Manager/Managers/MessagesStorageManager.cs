using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notifications.Manager.Configurations.Models;
using Notifications.Manager.Managers.Interfaces;
using Notifications.Manager.Models;

namespace Notifications.Manager.Managers
{
    public class MessagesStorageManager : IMessagesStorageManager
    {
        private readonly IUnitOfWork _uow;
        AppConfiguration _configuration;
        public MessagesStorageManager(IUnitOfWork uow, AppConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<Message>> GetAlldAsync()
            => await _uow.MessagesRepository.GetAllAsync();

        public async Task<IReadOnlyList<Message>> GetByIdsAsync(IEnumerable<long> ids)
            => await _uow.MessagesRepository.GetByIdsAsync(ids);

        public async Task<Message> GetByIdAsync(long id)
            => await _uow.MessagesRepository.GetByIdAsync(id);

        public async Task<int> CreateAsync(Message item)
        {
            var result = await _uow.MessagesRepository.CreateAsync(item);
            _uow.Commit();
            return result;
        }


        public async Task<int> UpdateAsync(Message item)
        {
            var result = await _uow.MessagesRepository.UpdateByUserSearchAsync(item);
            _uow.Commit();
            return result;
        }

        public async Task<int> DeleteAsync(long id)
        {
            var result = await _uow.MessagesRepository.DeleteAsync(id);
            _uow.Commit();
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if ( disposing )
            {
                ReleaseUnmanagedResources();
            }
        }

        private void ReleaseUnmanagedResources()
        {
            _uow.Dispose();
        }

        ~MessagesStorageManager()
        {
            Dispose(false);
        }
    }
}
