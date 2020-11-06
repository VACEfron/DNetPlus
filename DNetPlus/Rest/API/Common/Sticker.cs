using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API
{
    internal class Sticker
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }
        [JsonProperty("pack_id")]
        public ulong PackId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("tags")]
        public string? Tag { get; set; }
        [JsonProperty("asset")]
        public string Asset { get; set; }
        [JsonProperty("preview_asset")]
        public string PreviewAsset { get; set; }
        [JsonProperty("format_type")]
        public StickerType Type { get; set; }
    }
    public enum StickerType
    {
        Png = 1,
        Apng = 2,
        Lottie = 3
    }
}
