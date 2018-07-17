using System;
using System.Linq;

namespace ESP.Standard.Infrastructure.Install
{
    public class ServiceInstallerFinder
    {
        public IServiceInstaller[] Find()
        {
            var assemblyLoader = new AssemblyLoader();
            var assemblies = assemblyLoader.Load();

            Type baseType = typeof(IServiceInstaller);
            Type[] types = assemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                .ToArray();

            var installers = types.Select(t => (IServiceInstaller)Activator.CreateInstance(t));
            return installers.ToArray();
        }
    }
}
