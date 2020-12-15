using System.Linq;

using Model = Discord.API.AuditLog;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.Rest
{
    /// <summary>
    ///     Contains a piece of audit log data related to the deletion of a permission overwrite.
    /// </summary>
    public class OverwriteDeleteAuditLogData : IAuditLogData
    {
        private OverwriteDeleteAuditLogData(ulong channelId, Overwrite deletedOverwrite)
        {
            ChannelId = channelId;
            Overwrite = deletedOverwrite;
        }

        internal static OverwriteDeleteAuditLogData Create(BaseDiscordClient discord, Model log, EntryModel entry)
        {
            API.AuditLogChange[] changes = entry.Changes;

            API.AuditLogChange denyModel = changes.FirstOrDefault(x => x.ChangedProperty == "deny");
            API.AuditLogChange allowModel = changes.FirstOrDefault(x => x.ChangedProperty == "allow");

            ulong deny = denyModel.OldValue.ToObject<ulong>(discord.ApiClient.Serializer);
            ulong allow = allowModel.OldValue.ToObject<ulong>(discord.ApiClient.Serializer);

            OverwritePermissions permissions = new OverwritePermissions(allow, deny);

            ulong id = entry.Options.OverwriteTargetId.Value;
            PermissionTarget type = entry.Options.OverwriteType;

            return new OverwriteDeleteAuditLogData(entry.TargetId.Value, new Overwrite(id, type, permissions));
        }

        /// <summary>
        ///     Gets the ID of the channel that the overwrite was deleted from.
        /// </summary>
        /// <returns>
        ///     A <see cref="ulong"/> representing the snowflake identifier for the channel that the overwrite was
        ///     deleted from.
        /// </returns>
        public ulong ChannelId { get; }
        /// <summary>
        ///     Gets the permission overwrite object that was deleted.
        /// </summary>
        /// <returns>
        ///     An <see cref="Overwrite"/> object representing the overwrite that was deleted.
        /// </returns>
        public Overwrite Overwrite { get; }
    }
}
