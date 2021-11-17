using System;
using System.Data;
using Data.Factories.Interfaces;
using Data.Repositories.DbRepositories;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IUsersRepository _usersRepository;
        private ISchemaCongiguration _configuration;

        public UnitOfWork(IDbConnectionFactory dbConnectionFactory, ISchemaCongiguration configuration,
            DatabaseConnectionTypes type = DatabaseConnectionTypes.Default
        )
        {
            _configuration = configuration;
            _connection = dbConnectionFactory.CreateDbConnection(type);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }


        public IUsersRepository UsersRepository
            => _usersRepository ??= new UsersDatabaseRepository(_transaction, _configuration.SchemaName);


        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _usersRepository = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                ReleaseUnmanagedResources();
            }
        }

        private void ReleaseUnmanagedResources()
        {
            _transaction?.Dispose();
            _transaction = null;
            _connection?.Dispose();
            _connection = null;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}