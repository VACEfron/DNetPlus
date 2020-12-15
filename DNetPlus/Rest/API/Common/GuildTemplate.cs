using Discord.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API
{
    internal class GuildTemplate
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("usage_count")]
        public int UsageCount { get; set; }
        [JsonProperty("creator_id")]
        public ulong CreatorId { get; set; }
        [JsonProperty("source_guild_id")]
        public ulong SourceGuildId { get; set; }
        [JsonProperty("creator")]
        public User Creator { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
    internal class GuildTemplateSnapshot : GuildTemplate
    {
        [JsonProperty("serialized_source_guild")]
        public GuildSnapshot Snapshot { get; set; }
    }
}
