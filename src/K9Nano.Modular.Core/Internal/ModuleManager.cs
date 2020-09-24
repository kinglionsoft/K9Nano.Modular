using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace K9Nano.Modular.Internal
{
    internal class ModuleManager : IModuleManager
    {
        private readonly IModuleNamesProvider _moduleNamesProvider;
        private readonly List<ModuleInfo> _modules;

        public ModuleManager(IModuleNamesProvider moduleNamesProvider)
        {
            _moduleNamesProvider = moduleNamesProvider;

            var moduleNames = _moduleNamesProvider.GetModuleNames().ToList();
            _modules = new List<ModuleInfo>(moduleNames.Count);
            Console.WriteLine($"{moduleNames.Count} modules found");
            for (var i = 0; i < moduleNames.Count; i++)
            {
                var moduleName = moduleNames[i];
                Console.WriteLine($"{i + 1}/{moduleNames.Count}: {moduleName} registering");
                var moduleAssembly = Assembly.Load(new AssemblyName(moduleName));
                _modules.Add(new ModuleInfo(moduleName, moduleAssembly));
            }
        }

        public IReadOnlyList<ModuleInfo> Modules => _modules;

        internal void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            var startupList = Modules.Select(x => x.CreateModuleStartup())
                .OrderBy(x => x.Order);
            foreach (var startup in startupList)
            {
                startup.ConfigureServices(services, configuration, env);
            }
        }

        internal void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var startupList = Modules.Select(x => x.CreateModuleStartup())
                .OrderBy(x => x.Order);
            foreach (var startup in startupList)
            {
                startup.Configure(app, env);
            }
        }
    }
}