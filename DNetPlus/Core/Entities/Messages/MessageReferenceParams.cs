using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord
{
    /// <summary>
    /// Not available yet
    /// </summary>
    public class MessageReferenceParams
    {
        [JsonProperty("guild_id")]
        public ulong? GuildId { get; set; }
        [JsonProperty("channel_id")]
        public ulong ChannelId { get; set; }
        [JsonProperty("message_id")]
        public ulong MessageId { get; set; }
    }
}
