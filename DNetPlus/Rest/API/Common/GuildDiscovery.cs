using Newtonsoft;
using Newtonsoft.Json;
using System;

namespace Discord.API
{
    internal class GuildDiscovery
    {
        [JsonProperty("guild_id")]
        public ulong GuildId { get; set; }
        [JsonProperty("primary_category_id")]
        public int PrimaryCategoryId { get; set; }
        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }
        [JsonProperty("emoji_discoverability_enabled")]
        public bool EmojiDiscoverabilityEnabled { get; set; }
        [JsonProperty("partner_actioned_timestamp")]
        public DateTimeOffset? PartnerActionedTimestamp { get; set; }
        [JsonProperty("partner_application_timestamp")]
        public DateTimeOffset? PartnerAppliedTimestamp { get; set; }
        [JsonProperty("category_ids")]
        public int[] Categories { get; set; }
    }
}
