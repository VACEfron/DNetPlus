using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API
{
    internal class GuildSnapshot
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("icon_hash")]
        public string IconHash { get; set; }
        [JsonProperty("verification_level")]
        public VerificationLevel VerificationLevel { get; set; }
        [JsonProperty("default_message_notifications")]
        public DefaultMessageNotifications DefaultMessageNotifications { get; set; }

        [JsonProperty("explicit_content_filter")]
        public ExplicitContentFilterLevel ExplicitContentFilter { get; set; }
        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }
        [JsonProperty("afk_timeout")]
        public int AFKTimeout { get; set; }
        [JsonProperty("roles")]
        public GuildSnapshotRole[] Roles { get; set; }
        [JsonProperty("channels")]
        public GuildSnapshotChannel[] Channels { get; set; }
        [JsonProperty("afk_channel_id")]
        public int? AFKChannelId { get; set; }
        [JsonProperty("system_channel_id")]
        public int? SystemChannelId { get; set; }
        [JsonProperty("system_channel_flags")]
        public SystemChannelMessageDeny SystemChannelFlags { get; set; }
    }
    internal class GuildSnapshotRole
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("color")]
        public uint Color { get; set; }
        [JsonProperty("hoist")]
        public bool Hoist { get; set; }
        [JsonProperty("mentionable")]
        public bool Mentionable { get; set; }
        [JsonProperty("permissions"), Int53]
        public ulong Permissions { get; set; }


    }
    internal class GuildSnapshotOverwrite
    {
        [JsonProperty("id")]
        public int TargetId { get; set; }
        [JsonProperty("type")]
        public PermissionTarget TargetType { get; set; }
        [JsonProperty("deny"), Int53]
        public ulong Deny { get; set; }
        [JsonProperty("allow"), Int53]
        public ulong Allow { get; set; }
    }
    internal class GuildSnapshotChannel
    {
        //Shared
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public ChannelType Type { get; set; }

        [JsonProperty("name")]
        public Optional<string> Name { get; set; }
        [JsonProperty("position")]
        public Optional<int> Position { get; set; }
        [JsonProperty("permission_overwrites")]
        public Optional<GuildSnapshotOverwrite[]> PermissionOverwrites { get; set; }
        [JsonProperty("parent_id")]
        public int? CategoryId { get; set; }

        //TextChannel
        [JsonProperty("topic")]
        public Optional<string> Topic { get; set; }

        [JsonProperty("nsfw")]
        public Optional<bool> Nsfw { get; set; }
        [JsonProperty("rate_limit_per_user")]
        public Optional<int> SlowMode { get; set; }

        //VoiceChannel
        [JsonProperty("bitrate")]
        public Optional<int> Bitrate { get; set; }
        [JsonProperty("user_limit")]
        public Optional<int> UserLimit { get; set; }
    }
}
