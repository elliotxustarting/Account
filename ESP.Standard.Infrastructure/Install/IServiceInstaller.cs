using System;
using Microsoft.Extensions.DependencyInjection;

namespace ESP.Standard.Infrastructure.Install
{
    public interface IServiceInstaller
    {
        InstallLevel InstallLevel { get; set; }

        void AddService(IServiceCollection services);
    }
}
