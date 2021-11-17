using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Notifications.Manager.Configurations.Models;
using Notifications.Manager.Models;
using Notifications.Manager.Repositories.Interfaces;
using Dapper;

namespace Notifications.Manager.Repositories
{
    public class MessagesRepository : BaseDatabaseRepository, IMessagesRepository
    {
        public MessagesRepository(IDbTransaction transaction, AppConfiguration ñonfiguration)
            : base(transaction, ñonfiguration) { }
        public async Task<Message> GetByIdAsync(long id)
        {
            var sql = $@"
                SELECT * FROM {SchemaName}.messages
                WHERE messages.message_id = @id
            ";
            var result = await Connection.QueryAsync<Message>(sql, new { id });
            return result.SingleOrDefault();
        }

        public async Task<IReadOnlyList<Message>> GetByIdsAsync(IEnumerable<long> ids)
        {
            var sql = $@"
                SELECT * FROM {SchemaName}.messages
                WHERE messages.message_id = any (@ids)
            ";
            var result = await Connection.QueryAsync<Message>(sql, new { ids });
            return result.ToImmutableList();
        }

        public async Task<IReadOnlyList<Message>> GetAllAsync()
        {
            var sql = $@"
                SELECT * FROM {SchemaName}.messages
            ";
            var result = await Connection.QueryAsync<Message>(sql);
            return result.ToImmutableList();
        }
        
        public async Task<int> CreateAsync(Message entity)
        {
            if ( entity == null ) return 0;

            var sql = $@"
                INSERT INTO {SchemaName}.messages (user_id, type, text)
                VALUES (@UserId, '{entity.Type}', @Text)
            ";
            return await Connection.ExecuteAsync(sql, entity, Transaction);
        }

        public async Task<int> UpdateByUserSearchAsync(Message entity)
        {
            if ( entity == null ) return 0;

            var sql = $@"
                UPDATE {SchemaName}.messages
                SET user_id = @UserId,
                    type = '{entity.Type}',
                    text = @Text
                WHERE message_id = @MessageId
            ";

            return await Connection.ExecuteAsync(sql, entity, Transaction);
        }

        public async Task<int> DeleteAsync(long id)
        {
            var sql = $@"
                DELETE FROM {SchemaName}.messages
                WHERE message_id = @id
            ";
            return await Connection.ExecuteAsync(sql, new { id }, Transaction);
        }
    }
}