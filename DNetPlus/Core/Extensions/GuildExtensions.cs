using DNetPlus.Core.Entities.Guilds;

namespace Discord
{
    /// <summary>
    ///     An extension class for <see cref="IGuild"/>.
    /// </summary>
    public static class GuildExtensions
    {
        /// <summary>
        ///     Gets if welcome system messages are enabled.
        /// </summary>
        /// <param name="guild"> The guild to check. </param>
        /// <returns> A <c>bool</c> indicating if the welcome messages are enabled in the system channel. </returns>
        public static bool GetWelcomeMessagesEnabled(this IGuild guild)
            => !guild.SystemChannelFlags.HasFlag(SystemChannelMessageDeny.WelcomeMessage);

        /// <summary>
        ///     Gets if guild boost system messages are enabled.
        /// </summary>
        /// <param name="guild"> The guild to check. </param>
        /// <returns> A <c>bool</c> indicating if the guild boost messages are enabled in the system channel. </returns>
        public static bool GetGuildBoostMessagesEnabled(this IGuild guild)
            => !guild.SystemChannelFlags.HasFlag(SystemChannelMessageDeny.GuildBoost);

        /// <summary>
        ///    Gets a guilds feature set.
        /// </summary>
        /// <param name="guild"> The guild to check. </param>
        /// <returns> Returns a <see cref="GuildFeatures"/> that has a bool indicating if any features are available for the guild. </returns>
        public static GuildFeatures GetGuildFeatures(this IGuild guild)
        {
            GuildFeatures features = new GuildFeatures();
            if (guild.Features.Count == 0)
                return features;
            foreach(string s in guild.Features)
            {
                switch (s)
                {
                    case "INVITE_SPLASH":
                        features.InviteSplash = true;
                        break;
                    case "VIP_REGIONS":
                        features.VipRegions = true;
                        break;
                    case "VANITY_URL":
                        features.VanityUrl = true;
                        break;
                    case "VERIFIED":
                        features.Verified = true;
                        break;
                    case "PARTNERED":
                        features.Partnered = true;
                        break;
                    case "COMMERCE":
                        features.Commerce = true;
                        break;
                    case "NEWS":
                        features.News = true;
                        break;
                    case "DISCOVERABLE":
                        features.Discoverable = true;
                        break;
                    case "FEATURABLE":
                        features.Featurable = true;
                        break;
                    case "ANIMATED_ICON":
                        features.AnimatedIcon = true;
                        break;
                    case "BANNER":
                        features.Banner = true;
                        break;
                    case "WELCOME_SCREEN_ENABLED":
                        features.WelcomeScreen = true;
                        break;
                    case "COMMUNITY":
                        features.Community = true;
                        break;
                    case "ENABLED_DISCOVERABLE_BEFORE":
                        features.DiscoverableOld = true;
                        break;
                }
            }
            return features;
        }
    }
}
