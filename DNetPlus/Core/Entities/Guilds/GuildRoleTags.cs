using Discord.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord
{
    public class GuildRoleTags
    {
        public GuildRoleTags(RoleTags tags)
        {
            if (tags != null)
            {
                IntegrationId = tags.IntegrationId.HasValue ? tags.IntegrationId.Value : Optional.Create<ulong>();
                BotId = tags.BotId.HasValue ? tags.BotId.Value : Optional.Create<ulong>();
                IsBoostRole = !tags.PremiumId.HasValue;
            }
        }
        public Optional<ulong> IntegrationId { get; private set; }
        public Optional<ulong> BotId { get; private set; }
        public bool IsBoostRole { get; private set; }
    }
}
