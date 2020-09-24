using System;

namespace K9Nano.Modular
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public sealed class ModuleNameAttribute : Attribute
    {
        public ModuleNameAttribute(string name)
        {
            Name = name ?? string.Empty;
        }

        /// <Summary>
        /// The package or project name of the referenced module.
        /// </Summary>
        public string Name { get; }
    }
}