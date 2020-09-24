using System.Collections.Generic;

namespace K9Nano.Modular
{
    public interface IModuleManager
    {
        IReadOnlyList<ModuleInfo> Modules { get; }
    }
}