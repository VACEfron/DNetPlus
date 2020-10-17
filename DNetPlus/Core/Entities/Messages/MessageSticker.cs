using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API
{
    public class MessageSticker : ISticker
    {
        public ulong Id { get; internal set; }
        public ulong PackId { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public string? Tag { get; internal set; }
        public string Asset { get; internal set; }
        public string PreviewAsset { get; internal set; }
        public StickerType Type { get; internal set; }
    }
}
