using Core.StorageManagers;
using Core.StorageManagers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Configuration
{
    public static class StorageManagersConfiguration
    {
        /// <summary>
        /// Регистрирует как Scoped все StorageManager, используемые в проекте
        /// </summary>
        /// <param name="services"></param>
        public static void AddStorageManagers(this IServiceCollection services)
        {
            services.AddScoped<IUsersStorageManager, UsersStorageManager>();
        }
    }
}
