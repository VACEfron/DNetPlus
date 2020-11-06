using Discord.API;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Model = Discord.API.GuildSnapshot;

namespace Discord.Rest
{
    public class RestGuildSnapshot
    {
        private ImmutableDictionary<int, RestGuildSnapshotRole> _roles;
        public IReadOnlyCollection<RestGuildSnapshotRole> Roles => _roles.ToReadOnlyCollection();
        private ImmutableDictionary<int, RestGuildSnapshotChannel> _channels;
        public IReadOnlyCollection<RestGuildSnapshotChannel> Channels => _channels.ToReadOnlyCollection();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Region { get; private set; }
        public string IconHash { get; private set; }
        public VerificationLevel VerificationLevel { get; private set; }
        public DefaultMessageNotifications DefaultMessageNotifications { get; private set; }

        public ExplicitContentFilterLevel ExplicitContentFilter { get; private set; }
        public string PreferredLocale { get; private set; }
        public int AFKTimeout { get; private set; }
        
        public int? AFKChannelId { get; private set; }
        public int? SystemChannelId { get; private set; }
        public SystemChannelMessageDeny SystemChannelFlags { get; private set; }

        internal static RestGuildSnapshot Create(BaseDiscordClient discord, Model model)
        {
            RestGuildSnapshot entity = new RestGuildSnapshot
            {
                Name = model.Name,
                AFKTimeout = model.AFKTimeout,
                DefaultMessageNotifications = model.DefaultMessageNotifications,
                Description = model.Description,
                ExplicitContentFilter = model.ExplicitContentFilter,
                IconHash = model.IconHash,
                PreferredLocale = model.PreferredLocale,
                Region = model.Region,
                SystemChannelFlags = model.SystemChannelFlags,
                VerificationLevel = model.VerificationLevel
            };
            if (model.AFKChannelId.HasValue)
                entity.AFKChannelId = model.AFKChannelId.Value;
            if (model.SystemChannelId.HasValue)
                entity.SystemChannelId = model.SystemChannelId.Value;

            var roles = ImmutableDictionary.CreateBuilder<int, RestGuildSnapshotRole>();
            if (model.Roles != null)
            {
                for (int i = 0; i < model.Roles.Length; i++)
                    roles[model.Roles[i].Id] = RestGuildSnapshotRole.Create(model.Roles[i]);
            }
            entity._roles = roles.ToImmutable();

            var channels = ImmutableDictionary.CreateBuilder<int, RestGuildSnapshotChannel>();
            if (model.Channels != null)
            {
                for (int i = 0; i < model.Channels.Length; i++)
                    channels[model.Channels[i].Id] = RestGuildSnapshotChannel.Create(model.Channels[i]);
            }
            entity._channels = channels.ToImmutable();

            return entity;
        }
    }
    public class RestGuildSnapshotRole
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public uint Color { get; private set; }
        public bool Hoist { get; private set; }
        public bool Mentionable { get; private set; }
        public ulong Permissions { get; private set; }

        internal static RestGuildSnapshotRole Create(GuildSnapshotRole role)
        {
            RestGuildSnapshotRole entity = new RestGuildSnapshotRole
            {
                Color = role.Color,
                Hoist = role.Hoist,
                Id = int.Parse(role.Id.ToString()),
                Mentionable = role.Mentionable,
                Name = role.Name,
                Permissions = role.Permissions
            };
            return entity;
        }
    }
    public class RestGuildSnapshotOverwrite
    {
        /// <summary>
        ///     Gets the unique identifier for the object this overwrite is targeting.
        /// </summary>
        public int TargetId { get; private set; }
        /// <summary>
        ///     Gets the type of object this overwrite is targeting.
        /// </summary>
        public PermissionTarget TargetType { get; private set; }
        /// <summary>
        ///     Gets the permissions associated with this overwrite entry.
        /// </summary>
        public OverwritePermissions Permissions { get; private set; }
        internal static RestGuildSnapshotOverwrite Create(GuildSnapshotOverwrite model)
        {
            return new RestGuildSnapshotOverwrite
            {
                TargetType = model.TargetType,
                TargetId = model.TargetId,
                Permissions = new OverwritePermissions
                {
                    DenyValue = model.Deny,
                    AllowValue = model.Allow
                }
            };
        }
    }
    public class RestGuildSnapshotChannel
    {
        public int Id { get; private set; }
        public ChannelType Type { get; private set; }

        public Optional<string> Name { get; private set; }
        public Optional<int> Position { get; private set; }
        public Optional<RestGuildSnapshotOverwrite[]> PermissionOverwrites { get; private set; }
        public int? CategoryId { get; private set; }

        //TextChannel
        public Optional<string> Topic { get; private set; }

        public Optional<bool> Nsfw { get; private set; }
        public Optional<int> SlowMode { get; private set; }

        //VoiceChannel
        public Optional<int> Bitrate { get; private set; }
        public Optional<int> UserLimit { get; private set; }

        internal static RestGuildSnapshotChannel Create(GuildSnapshotChannel model)
        {
            RestGuildSnapshotChannel entity = new RestGuildSnapshotChannel
            {
                Bitrate = model.Bitrate,
                Id = int.Parse(model.Id.ToString()),
                Name = model.Name,
                Nsfw = model.Nsfw,
                Position = model.Position,
                SlowMode = model.SlowMode,
                Topic = model.Topic,
                Type = model.Type,
                UserLimit = model.UserLimit
            };
            if (model.CategoryId.HasValue)
                entity.CategoryId = model.CategoryId.Value;
            if (model.PermissionOverwrites.IsSpecified)
                entity.PermissionOverwrites = model.PermissionOverwrites.Value.Select(x => RestGuildSnapshotOverwrite.Create(x)).ToArray();

            return entity;
        }
    }
}
