namespace DefiningClassesPartTwo
{
    using System;

    [AttributeUsage(AttributeTargets.Struct |AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class VersionAttribute : Attribute
    {
        public string Version { get; private set; }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}
