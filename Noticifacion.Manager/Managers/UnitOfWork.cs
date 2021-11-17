using System;
using System.Data;
using Notifications.Manager.Configurations.Models;
using Notifications.Manager.Managers.Interfaces;
using Notifications.Manager.Repositories;
using Notifications.Manager.Repositories.Interfaces;
using Npgsql;

namespace Notifications.Manager.Managers
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IMessagesRepository _messagesRepository;
        private AppConfiguration _configuration;
        public UnitOfWork(AppConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new NpgsqlConnection(configuration.ConnectionStrings.DefaultConnection);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IMessagesRepository MessagesRepository
            => _messagesRepository ??= new MessagesRepository(_transaction, _configuration);



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
            _messagesRepository = null;
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