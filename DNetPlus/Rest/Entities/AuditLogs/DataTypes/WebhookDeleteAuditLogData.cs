using System.Linq;

using Model = Discord.API.AuditLog;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.Rest
{
    /// <summary>
    ///     Contains a piece of audit log data related to a webhook deletion.
    /// </summary>
    public class WebhookDeleteAuditLogData : IAuditLogData
    {
        private WebhookDeleteAuditLogData(ulong id, ulong channel, WebhookType type, string name, string avatar)
        {
            WebhookId = id;
            ChannelId = channel;
            Name = name;
            Type = type;
            Avatar = avatar;
        }

        internal static WebhookDeleteAuditLogData Create(BaseDiscordClient discord, Model log, EntryModel entry)
        {
            API.AuditLogChange[] changes = entry.Changes;

            API.AuditLogChange channelIdModel = changes.FirstOrDefault(x => x.ChangedProperty == "channel_id");
            API.AuditLogChange typeModel = changes.FirstOrDefault(x => x.ChangedProperty == "type");
            API.AuditLogChange nameModel = changes.FirstOrDefault(x => x.ChangedProperty == "name");
            API.AuditLogChange avatarHashModel = changes.FirstOrDefault(x => x.ChangedProperty == "avatar_hash");

            ulong channelId = channelIdModel.OldValue.ToObject<ulong>(discord.ApiClient.Serializer);
            WebhookType type = typeModel.OldValue.ToObject<WebhookType>(discord.ApiClient.Serializer);
            string name = nameModel.OldValue.ToObject<string>(discord.ApiClient.Serializer);
            string avatarHash = avatarHashModel?.OldValue?.ToObject<string>(discord.ApiClient.Serializer);

            return new WebhookDeleteAuditLogData(entry.TargetId.Value, channelId, type, name, avatarHash);
        }

        /// <summary>
        ///     Gets the ID of the webhook that was deleted.
        /// </summary>
        /// <returns>
        ///     A <see cref="ulong"/> representing the snowflake identifier of the webhook that was deleted.
        /// </returns>
        public ulong WebhookId { get; }
        /// <summary>
        ///     Gets the ID of the channel that the webhook could send to.
        /// </summary>
        /// <returns>
        ///     A <see cref="ulong"/> representing the snowflake identifier of the channel that the webhook could send
        ///     to.
        /// </returns>
        public ulong ChannelId { get; }
        /// <summary>
        ///     Gets the type of the webhook that was deleted.
        /// </summary>
        /// <returns>
        ///     The type of webhook that was deleted.
        /// </returns>
        public WebhookType Type { get; }
        /// <summary>
        ///     Gets the name of the webhook that was deleted.
        /// </summary>
        /// <returns>
        ///     A string containing the name of the webhook that was deleted.
        /// </returns>
        public string Name { get; }
        /// <summary>
        ///     Gets the hash value of the webhook's avatar.
        /// </summary>
        /// <returns>
        ///     A string containing the hash of the webhook's avatar.
        /// </returns>
        public string Avatar { get; }
    }
}
