using System;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Infrastructure.Install;
using Microsoft.Extensions.DependencyInjection;

namespace ESP.Standard.Account.Provider.Install
{
    public class ProviderServiceInstaller : IServiceInstaller
    {
        public ProviderServiceInstaller()
        {
            InstallLevel = InstallLevel.Business;
        }

        public InstallLevel InstallLevel { get; set; }

        public void AddService(IServiceCollection services)
        {
            services.AddTransient<IOrganizationProvider, OrganizationProvider>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<IRoleProvider, RoleProvider>();
            services.AddTransient<IPermissionProvider, PermissionProvider>();
            services.AddTransient<IElementProvider, ElementProvider>();
            services.AddTransient<IMenuProvider, MenuProvider>();
        }
    }
}
