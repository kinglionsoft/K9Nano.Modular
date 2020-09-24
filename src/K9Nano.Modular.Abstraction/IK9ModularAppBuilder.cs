using Microsoft.Extensions.DependencyInjection;

namespace K9Nano.Modular
{
    public interface IK9ModularAppBuilder
    {
        IServiceCollection Services { get; }

        IModuleManager ModuleManager { get; }
    }
}