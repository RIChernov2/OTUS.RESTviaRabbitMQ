﻿using Microsoft.Extensions.DependencyInjection;

namespace Notifications.Manager.Configurations
{
    /// <summary>
    /// Исправляет меппинг CamelCase в snake_case
    /// иначе при обращении к базе даппер не сопоставляет (например) user_id из БД
    /// и поля UserId класса, поле получает значение по умолчанию
    /// </summary>
    public static class DapperConfiguration
    {
        public static void Configure()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
