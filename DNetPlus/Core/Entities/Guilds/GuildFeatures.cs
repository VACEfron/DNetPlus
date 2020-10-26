using System;
using System.Collections.Generic;
using System.Text;

namespace DNetPlus.Core.Entities.Guilds
{
    public class GuildFeatures
    {
        /// <summary>
        /// 	Guild has access to set an invite splash background.
        /// </summary>
        public bool InviteSplash { get; internal set; }
        /// <summary>
        /// Guild has access to set 384kbps bitrate in voice. (previously VIP voice servers)
        /// </summary>
        public bool VipRegions { get; internal set; }
        /// <summary>
        /// 	Guild has access to set a vanity URL.
        /// </summary>
        public bool VanityUrl { get; internal set; }
        /// <summary>
        /// 	Guild is verified by Discord.
        /// </summary>
        public bool Verified { get; internal set; }
        /// <summary>
        /// Guild is partnered by Discord.
        /// </summary>
        public bool Partnered { get; internal set; }
        /// <summary>
        /// Guild has access to use commerce features. (i.e. create store channels)
        /// </summary>
        public bool Commerce { get; internal set; }
        /// <summary>
        /// Guild has access to create news channels.
        /// </summary>
        public bool News { get; internal set; }
        /// <summary>
        /// Guild is lurkable and able to be discovered in the directory.
        /// </summary>
        public bool Discoverable { get; internal set; }
        /// <summary>
        /// Guild is able to be featured in the directory.
        /// </summary>
        public bool Featurable { get; internal set; }
        /// <summary>
        /// Guild has access to set an animated guild icon.
        /// </summary>
        public bool AnimatedIcon { get; internal set; }
        /// <summary>
        /// Guild has access to set a guild banner image.
        /// </summary>
        public bool Banner { get; internal set; }
        /// <summary>
        /// Guild has enabled the welcome screen.
        /// </summary>
        public bool WelcomeScreen { get; internal set; }
        /// <summary>
        /// Guild can enable welcome screen and discovery, and receives community updates.
        /// </summary>
        public bool Community { get; internal set; }
        /// <summary>
        /// Guild is lurkable and able to be discovered in the directory.
        /// </summary>
        public bool DiscoverableOld { get; internal set; }
    }
}
