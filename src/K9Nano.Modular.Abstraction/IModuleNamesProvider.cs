using System.Collections.Generic;

namespace K9Nano.Modular
{
    public interface IModuleNamesProvider
    {
        IEnumerable<string> GetModuleNames();
    }
}