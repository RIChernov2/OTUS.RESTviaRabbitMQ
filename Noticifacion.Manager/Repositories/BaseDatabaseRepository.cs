using Notifications.Manager.Configurations.Models;
using System.Data;

namespace Notifications.Manager.Repositories
{
    public abstract class BaseDatabaseRepository
    {
        protected IDbTransaction Transaction { get; }
        protected IDbConnection Connection => Transaction?.Connection;
        protected string SchemaName { get; set; }

        protected BaseDatabaseRepository(IDbTransaction transaction, AppConfiguration �onfiguration)
        {
            Transaction = transaction;
            SchemaName = �onfiguration.SchemaName;
        }
    }
}