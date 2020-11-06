using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Discord.API
{
    public class RoleTags
    {
        [JsonProperty("bot_id")]
        public ulong? BotId { get; set; }
        [JsonProperty("integration_id")]
        public ulong? IntegrationId { get; set; }
        [JsonProperty("premium_subscriber")]
        public ulong? PremiumId { get; set; } = 0;
    }
}
