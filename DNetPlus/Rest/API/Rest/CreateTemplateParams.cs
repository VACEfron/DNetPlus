using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API.Rest
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class CreateTemplateParams
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
