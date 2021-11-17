using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.DbRepositories
{
    public class UsersDatabaseRepository : BaseDatabaseRepository, IUsersRepository
    {
        public UsersDatabaseRepository(IDbTransaction transaction, string schemaName) 
            : base(transaction, schemaName)
        {
        }


        public async Task<User> GetByIdAsync(long userId)
        {
            var sql = $@"
                SELECT * FROM {_schema}.users
                WHERE users.user_id = @userId
            ";
            var result = await Connection.QueryAsync<User>(sql, new { userId });
            return result.SingleOrDefault();
        }

        public async Task<IReadOnlyList<User>> GetByIdsAsync(IEnumerable<long> userIds)
        {
            var sql = $@"
                SELECT * FROM {_schema}.users
                WHERE users.user_id = any (@userIds)
            ";
            var result = await Connection.QueryAsync<User>(sql, new { userIds });
            return result.ToImmutableList();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = $@"
                SELECT * FROM {_schema}.users
            ";
            var result = await Connection.QueryAsync<User>(sql);
            return result.ToImmutableList();
        }

        public async Task<int> CreateAsync(User entity)
        {
            if ( entity == null ) return 0;

            var sql =  $@"
                INSERT INTO {_schema}.users (name, surname, age)
                VALUES (@Name, @Surname, @Age)
            ";
            return await Connection.ExecuteAsync(sql, entity, Transaction);
        }

        public async Task<int> UpdateAsync(User entity)
        {
            if ( entity == null ) return 0;


            var sql = $@"
                UPDATE {_schema}.users
                SET name = @Name,
                    surname = @Surname,
                    age = @Age
                WHERE user_id = @UserId
            ";
            return await Connection.ExecuteAsync(sql, entity, Transaction);
        }

        public async Task<int> DeleteAsync(long userId)
        {
            var sql = $@"
                DELETE FROM {_schema}.users
                WHERE user_id = @userId
            ";
            return await Connection.ExecuteAsync(sql, new { userId }, Transaction);
        }

    }
}