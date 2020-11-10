using System;
using Model = Discord.API.GuildDiscovery;

namespace Discord.Rest
{
    /// <summary>
    ///     Represents a REST-based Discovery metadata object guild/server.
    /// </summary>
    public struct RestGuildDiscovery
    {
        private long _partnerActioned;
        private long _partnerApplied;
        /// <summary>
        /// The id of the parent guild.
        /// </summary>
        public ulong GuildId { get; set; }
        /// <summary>
        /// The main discovery category that the guild is shown in.
        /// </summary>
        public int PrimaryCategoryId { get; set; }
        /// <summary>
        /// Search keywords so that other people can find the guild.
        /// </summary>
        public string[] Keywords { get; set; }
        /// <summary>
        /// Allow emotes to be globally clicked on to display this guild that they came from.
        /// </summary>
        public bool EmojiDiscoverabilityEnabled { get; set; }

        /// <summary>
        /// The date when the guild was given partner by Discord.
        /// </summary>
        public DateTimeOffset? PartnerGivenAt 
        { 
            get 
            {
                if (_partnerActioned == 0)
                    return null;
                else
                {
                    return DateTimeUtils.FromTicks(_partnerActioned);
                }
            }
        }
        /// <summary>
        /// The date when you applied the guild for partnership.
        /// </summary>
        public DateTimeOffset? PartnerAppliedAt
        {
            get
            {
                if (_partnerApplied == 0)
                    return null;
                else
                    return DateTimeUtils.FromTicks(_partnerApplied);
            }
        }
        /// <summary>
        /// Optional categories that the guild can be shown in.
        /// </summary>
        public int[] CategoryIds { get; set; }

        internal static RestGuildDiscovery Create(Model model)
        {
            RestGuildDiscovery entity = new RestGuildDiscovery();
            entity.Update(model);
            return entity;
        }

        internal void Update(Model model)
        {
            GuildId = model.GuildId;
            PrimaryCategoryId = model.PrimaryCategoryId;
            Keywords = model.Keywords ?? new string[0] { };
            EmojiDiscoverabilityEnabled = model.EmojiDiscoverabilityEnabled;
            CategoryIds = model.Categories ?? new int[0] { };
            _partnerActioned = model.PartnerActionedTimestamp.HasValue ? model.PartnerActionedTimestamp.Value.UtcTicks : 0;
            _partnerApplied = model.PartnerAppliedTimestamp.HasValue ? model.PartnerAppliedTimestamp.Value.UtcTicks : 0;
        }
    }
}
