using System;
using System.Collections.Generic;
using System.Text;

namespace Discord.API
{
    public interface ISticker
    {
        ulong Id { get; }
        ulong PackId { get; }
        string Name { get; }
        string Description { get; }
        string? Tag { get;  }
        string Asset { get;  }
        string PreviewAsset { get; }
        StickerType Type { get; }
    }
}
