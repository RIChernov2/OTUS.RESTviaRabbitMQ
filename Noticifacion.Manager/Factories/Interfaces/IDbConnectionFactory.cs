﻿
using System.Data;

namespace Notifications.Manager.Factories.Interfaces
{
    public enum DatabaseConnectionTypes
    {
        Default
    }

    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionTypes connectionType);
    }
}
