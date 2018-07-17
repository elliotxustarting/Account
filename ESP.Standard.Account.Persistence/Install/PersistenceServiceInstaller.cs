using System;
using ESP.Standard.Infrastructure.Install;
using Microsoft.Extensions.DependencyInjection;

namespace ESP.Standard.Account.Persistence.Install
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public PersistenceServiceInstaller()
        {
            InstallLevel = InstallLevel.Persistence;
        }

        public InstallLevel InstallLevel { get; set; }

        public void AddService(IServiceCollection services)
        {
            services.AddSingleton<UserDao>();
            services.AddSingleton<AccountDao>();
            services.AddSingleton<OrganizationDao>();
            services.AddSingleton<ElementDao>();
            services.AddSingleton<MenuDao>();
            services.AddSingleton<PermissionDao>();
            services.AddSingleton<RoleDao>();
        }
    }
}
