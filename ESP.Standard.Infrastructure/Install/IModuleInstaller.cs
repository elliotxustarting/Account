using System;
namespace ESP.Standard.Infrastructure.Install
{
    public interface IModuleInstaller : IServiceInstaller
    {
        void AddModule();
    }
}
