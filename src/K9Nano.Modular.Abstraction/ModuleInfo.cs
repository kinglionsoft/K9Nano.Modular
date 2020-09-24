using System;
using System.Linq;
using System.Reflection;

namespace K9Nano.Modular
{
    public sealed class ModuleInfo
    {
        public string Name { get; }

        public Assembly Assembly { get; }

        public ModuleInfo(string name, Assembly assembly)
        {
            Name = name;
            Assembly = assembly;
        }

        public IModuleStartup CreateModuleStartup()
        {
            var startupType = Assembly.GetTypes()
                   .FirstOrDefault(x => x.IsClass
                                        && !x.IsAbstract
                                        && x.GetInterface(nameof(IModuleStartup)) != null);

            if (startupType == null)
            {
                throw new Exception($"Can not find implementation of IModuleStartup in {Assembly}");
            }

            var startup = (IModuleStartup)Activator.CreateInstance(startupType);
            return startup;
        }
    }
}