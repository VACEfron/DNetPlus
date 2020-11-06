using System;
using System.Collections.Generic;
using System.Text;

namespace Discord
{
    public interface IGuildTemplate
    {
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }
        public int UsageCount { get; }
        public ulong CreatorId { get; }
        public IUser Creator { get; }
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset UpdatedAt { get; }
        public ulong SourceGuildId { get; }
        public Optional<Rest.RestGuildSnapshot> Snapshot { get; }
    }
}
