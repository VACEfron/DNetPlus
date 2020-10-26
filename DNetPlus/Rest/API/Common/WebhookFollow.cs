using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API
{
    public class WebhookFollow
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
