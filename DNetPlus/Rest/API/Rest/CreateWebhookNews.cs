using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API.Rest
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class CreateWebhookNews
    {
        public CreateWebhookNews(ulong target)
        {
            targetChannelId = target;
        }
        [JsonProperty("webhook_channel_id")]
        public ulong targetChannelId { get; }
    }
}
