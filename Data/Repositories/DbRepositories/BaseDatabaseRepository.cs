using System.Data;

namespace Data.Repositories.DbRepositories
{
    public abstract class BaseDatabaseRepository
    {
        protected IDbTransaction Transaction { get; }
        protected IDbConnection Connection => Transaction?.Connection;

        protected BaseDatabaseRepository(IDbTransaction transaction, string schemaName)
        {
            Transaction = transaction;
            _schema = schemaName;
        }
        protected string _schema;
    }
}