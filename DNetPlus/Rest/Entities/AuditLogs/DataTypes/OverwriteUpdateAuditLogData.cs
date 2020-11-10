using System.Linq;

using Model = Discord.API.AuditLog;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.Rest
{
    /// <summary>
    ///     Contains a piece of audit log data related to the update of a permission overwrite.
    /// </summary>
    public class OverwriteUpdateAuditLogData : IAuditLogData
    {
        private OverwriteUpdateAuditLogData(ulong channelId, OverwritePermissions before, OverwritePermissions after, ulong targetId, PermissionTarget targetType)
        {
            ChannelId = channelId;
            OldPermissions = before;
            NewPermissions = after;
            OverwriteTargetId = targetId;
            OverwriteType = targetType;
        }

        internal static OverwriteUpdateAuditLogData Create(BaseDiscordClient discord, Model log, EntryModel entry)
        {
            API.AuditLogChange[] changes = entry.Changes;

            API.AuditLogChange denyModel = changes.FirstOrDefault(x => x.ChangedProperty == "deny");
            API.AuditLogChange allowModel = changes.FirstOrDefault(x => x.ChangedProperty == "allow");

            ulong? beforeAllow = allowModel?.OldValue?.ToObject<ulong>(discord.ApiClient.Serializer);
            ulong? afterAllow = allowModel?.NewValue?.ToObject<ulong>(discord.ApiClient.Serializer);
            ulong? beforeDeny = denyModel?.OldValue?.ToObject<ulong>(discord.ApiClient.Serializer);
            ulong? afterDeny = denyModel?.NewValue?.ToObject<ulong>(discord.ApiClient.Serializer);

            OverwritePermissions beforePermissions = new OverwritePermissions(beforeAllow ?? 0, beforeDeny ?? 0);
            OverwritePermissions afterPermissions = new OverwritePermissions(afterAllow ?? 0, afterDeny ?? 0);

            PermissionTarget type = entry.Options.OverwriteType;

            return new OverwriteUpdateAuditLogData(entry.TargetId.Value, beforePermissions, afterPermissions, entry.Options.OverwriteTargetId.Value, type);
        }

        /// <summary>
        ///     Gets the ID of the channel that the overwrite was updated from.
        /// </summary>
        /// <returns>
        ///     A <see cref="ulong"/> representing the snowflake identifier for the channel that the overwrite was
        ///     updated from.
        /// </returns>
        public ulong ChannelId { get; }
        /// <summary>
        ///     Gets the overwrite permissions before the changes.
        /// </summary>
        /// <returns>
        ///     An overwrite permissions object representing the overwrite permissions that the overwrite had before
        ///     the changes were made.
        /// </returns>
        public OverwritePermissions OldPermissions { get; }
        /// <summary>
        ///     Gets the overwrite permissions after the changes.
        /// </summary>
        /// <returns>
        ///     An overwrite permissions object representing the overwrite permissions that the overwrite had after the
        ///     changes.
        /// </returns>
        public OverwritePermissions NewPermissions { get; }
        /// <summary>
        ///     Gets the ID of the overwrite that was updated.
        /// </summary>
        /// <returns>
        ///     A <see cref="ulong"/> representing the snowflake identifier of the overwrite that was updated.
        /// </returns>
        public ulong OverwriteTargetId { get; }
        /// <summary>
        ///     Gets the target of the updated permission overwrite.
        /// </summary>
        /// <returns>
        ///     The target of the updated permission overwrite.
        /// </returns>
        public PermissionTarget OverwriteType { get; }
    }
}
