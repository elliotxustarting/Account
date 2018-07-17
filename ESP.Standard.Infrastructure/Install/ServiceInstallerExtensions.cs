using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace ESP.Standard.Infrastructure.Install
{
    public static class ServiceInstallerExtensions
    {
        public static IServiceCollection Install(this IServiceCollection services)
        {
            var installerFinder = new ServiceInstallerFinder();
            var installers = installerFinder.Find().OrderBy(i => i.InstallLevel);
            foreach(var installer in installers)
            {
                installer.AddService(services);
            }
            return services;
        }
    }
}
