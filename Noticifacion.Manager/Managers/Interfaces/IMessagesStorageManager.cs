using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notifications.Manager.Models;

namespace Notifications.Manager.Managers.Interfaces
{
    public interface IMessagesStorageManager : IDisposable
    {
        public Task<IReadOnlyList<Message>> GetAlldAsync();
        public Task<IReadOnlyList<Message>> GetByIdsAsync(IEnumerable<long> ids);
        public Task<Message> GetByIdAsync(long id);
        public Task<int> CreateAsync(Message order);
        public Task<int> UpdateAsync(Message order);
        public Task<int> DeleteAsync(long id);
    }
}