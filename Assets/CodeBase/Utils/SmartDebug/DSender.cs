namespace CodeBase.Utils.SmartDebug
{
    public class DSender
    {
        public readonly string Name;

        public const DebugPlatform Platform = DebugPlatform.All;

        public DSender(string name) =>
            Name = name;
    }
}