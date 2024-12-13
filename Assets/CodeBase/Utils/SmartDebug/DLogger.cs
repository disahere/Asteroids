using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeBase.Utils.SmartDebug
{
    [UsedImplicitly]
    public static class DLogger
    {
        private static readonly Dictionary<DSender, string> CashedSenders = new();

        public static MessageBuilder Message(DSender sender) =>
            new(GetSenderName(sender), sender);

        private static string GetSenderName(DSender sender)
        {
            if (CashedSenders.TryGetValue(sender, out string senderName)) return senderName;
            senderName = sender.Name.Bold();
            CashedSenders.Add(sender, senderName);

            return senderName;
        }
    }
}