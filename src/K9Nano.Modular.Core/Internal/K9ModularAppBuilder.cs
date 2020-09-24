using Microsoft.Extensions.DependencyInjection;

namespace K9Nano.Modular.Internal
{
    internal class K9ModularAppBuilder : IK9ModularAppBuilder
    {
        public K9ModularAppBuilder(IServiceCollection services, IModuleManager moduleManager)
        {
            Services = services;
            ModuleManager = moduleManager;
        }

        public IServiceCollection Services { get; }

        public IModuleManager ModuleManager { get; }
    }
}