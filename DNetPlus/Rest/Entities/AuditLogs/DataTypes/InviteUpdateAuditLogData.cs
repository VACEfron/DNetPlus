using System.Linq;

using Model = Discord.API.AuditLog;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.Rest
{
    /// <summary>
    ///     Contains a piece of audit log data relating to an invite update.
    /// </summary>
    public class InviteUpdateAuditLogData : IAuditLogData
    {
        private InviteUpdateAuditLogData(InviteInfo before, InviteInfo after)
        {
            Before = before;
            After = after;
        }

        internal static InviteUpdateAuditLogData Create(BaseDiscordClient discord, Model log, EntryModel entry)
        {
            API.AuditLogChange[] changes = entry.Changes;

            API.AuditLogChange maxAgeModel = changes.FirstOrDefault(x => x.ChangedProperty == "max_age");
            API.AuditLogChange codeModel = changes.FirstOrDefault(x => x.ChangedProperty == "code");
            API.AuditLogChange temporaryModel = changes.FirstOrDefault(x => x.ChangedProperty == "temporary");
            API.AuditLogChange channelIdModel = changes.FirstOrDefault(x => x.ChangedProperty == "channel_id");
            API.AuditLogChange maxUsesModel = changes.FirstOrDefault(x => x.ChangedProperty == "max_uses");

            int? oldMaxAge = maxAgeModel?.OldValue?.ToObject<int>(discord.ApiClient.Serializer),
                newMaxAge = maxAgeModel?.NewValue?.ToObject<int>(discord.ApiClient.Serializer);
            string oldCode = codeModel?.OldValue?.ToObject<string>(discord.ApiClient.Serializer),
                newCode = codeModel?.NewValue?.ToObject<string>(discord.ApiClient.Serializer);
            bool? oldTemporary = temporaryModel?.OldValue?.ToObject<bool>(discord.ApiClient.Serializer),
                newTemporary = temporaryModel?.NewValue?.ToObject<bool>(discord.ApiClient.Serializer);
            ulong? oldChannelId = channelIdModel?.OldValue?.ToObject<ulong>(discord.ApiClient.Serializer),
                newChannelId = channelIdModel?.NewValue?.ToObject<ulong>(discord.ApiClient.Serializer);
            int? oldMaxUses = maxUsesModel?.OldValue?.ToObject<int>(discord.ApiClient.Serializer),
                newMaxUses = maxUsesModel?.NewValue?.ToObject<int>(discord.ApiClient.Serializer);

            InviteInfo before = new InviteInfo(oldMaxAge, oldCode, oldTemporary, oldChannelId, oldMaxUses);
            InviteInfo after = new InviteInfo(newMaxAge, newCode, newTemporary, newChannelId, newMaxUses);

            return new InviteUpdateAuditLogData(before, after);
        }

        /// <summary>
        ///     Gets the invite information before the changes.
        /// </summary>
        /// <returns>
        ///     An information object containing the original invite information before the changes were made.
        /// </returns>
        public InviteInfo Before { get; }
        /// <summary>
        ///     Gets the invite information after the changes.
        /// </summary>
        /// <returns>
        ///     An information object containing the invite information after the changes were made.
        /// </returns>
        public InviteInfo After { get; }
    }
}
