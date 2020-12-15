using Discord.API;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Model = Discord.API.GuildTemplate;

namespace Discord.Rest
{
    public class RestGuildTemplate : IGuildTemplate
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int UsageCount { get; private set; }
        public ulong CreatorId { get; private set; }
        public IUser Creator { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public ulong SourceGuildId { get; private set; }
        public Optional<RestGuildSnapshot> Snapshot { get; private set; }

        internal static RestGuildTemplate Create(BaseDiscordClient discord, Model model, bool withSnapshot)
        {
            RestGuildTemplate entity = new RestGuildTemplate();
            entity.Update(discord, model, withSnapshot);
            return entity;
        }
        internal void Update(BaseDiscordClient discord, Model model, bool withSnapshot)
        {
            Code = model.Code;
            Name = model.Name;
            Description = model.Description;
            UsageCount = model.UsageCount;
            CreatorId = model.CreatorId;
            Creator = RestUser.Create(discord, model.Creator);
          
            SourceGuildId = model.SourceGuildId;
            CreatedAt = model.CreatedAt;
            UpdatedAt = model.UpdatedAt;
            if (withSnapshot)
                Snapshot = RestGuildSnapshot.Create(discord, (model as GuildTemplateSnapshot).Snapshot);
        }
    }
}
