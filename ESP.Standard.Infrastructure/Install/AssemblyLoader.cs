using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace ESP.Standard.Infrastructure.Install
{
    public class AssemblyLoader
    {
        private string[] _filters;

        public AssemblyLoader()
        {
            _filters = new string[]
           {
                "System",
                "Microsoft",
                "netstandard",
                "dotnet",
                "Window",
                "mscorlib"
            };
        }

        public Assembly[] Load()
        {
            DependencyContext context = DependencyContext.Default;
            if (context != null)
            {
                List<string> names = new List<string>();
                string[] dllNames = context.CompileLibraries.SelectMany(m => m.Assemblies).Distinct().Select(m => m.Replace(".dll", "")).ToArray();
                if (dllNames.Length > 0)
                {
                    names = (from name in dllNames
                             let i = name.LastIndexOf('/') + 1
                             select name.Substring(i, name.Length - i)).Distinct()
                                                                       .Where(name => !_filters.Any(name.StartsWith))
                        .ToList();
                }
                return LoadFiles(names);
            }
            return new Assembly[0];
        }

        private static Assembly[] LoadFiles(IEnumerable<string> files)
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (string file in files)
            {
                AssemblyName name = new AssemblyName(file);
                try
                {
                    assemblies.Add(Assembly.Load(name));
                }
                catch (FileNotFoundException)
                { }
            }
            return assemblies.ToArray();
        }
    }
}
