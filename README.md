# Info
This is a fork of [Discord.net](https://github.com/discord-net/Discord.Net) v2.3.0-dev-20200904.2 with many tweaks and added functionality instead of waiting months for them.

# Install
Remove any discord.net packages such as discord.net.commands, discord.net.websocket, discord.net.webhook and install the package from nuget with https://www.nuget.org/packages/DNetPlus

# Addons
You can install these optional addons to extend the functionality of DNetPlus.
https://github.com/xXBuilderBXx/DNetPlus-Addons

# Fixes/Tweaks by me
- [Increase connection wait limit instead of timeouts](https://github.com/xXBuilderBXx/DNetPlus/commit/34e4cd07ea2147cf5fd449087a278567e14bb0b9)
   - This helps with bigger bots with 15+ shards to connect better.

- [Make GetShardForId public](https://github.com/xXBuilderBXx/DNetPlus/commit/9e5d4b99f5061538db87ef316e54bddfc262fe32)
   - Allows you to get a shard id from a guild id. Client.GetShardForId(12345)

- [Allowed mentions property on modifymessage](https://github.com/xXBuilderBXx/DNetPlus/commit/506bab4e1af5b1c3960040e6125cc7b4ce3a34d0)
   - Adds allowed mentions property when modifying a message, useful because editing a message resets allowed mentions by default.

- [Ignore integration update events](https://github.com/xXBuilderBXx/DNetPlus/commit/f8c8387c277525d9488abb2a0671d45b7b585008) | [Integration create/remove](https://github.com/xXBuilderBXx/DNetPlus/commit/f5b8c1d7585e92fae57bda4dcb419db15de9909b)
   - New event type that is now ignored instead of spamming console logs.

- [Expose config for client and add ownerids override list for team/external users](https://github.com/xXBuilderBXx/DNetPlus/commit/faec9248120cf808de68996763459d00348192da)
   - new DiscordSocketConfig { OwnerIds = new ulong[] { 190590364871032834 } };
   - This also works with RequireOwner command attribute.
   - Exposed config allows you to get Client.baseConfig properties from DiscordSocketConfig instead of being hidden.

- [Add command attribute for RequireTeamMember](https://github.com/xXBuilderBXx/DNetPlus/commit/4c7c9e31f0521ff9ff236a53a275e8b4f9b3f5dc)

- [Add command info to the command context](https://github.com/xXBuilderBXx/DNetPlus/commit/5c084d045d71ab908026b34adaaa4a2f2b808e18)
   - Allows you to get command info from the current command executed with Context.Command.

- [Customize version](https://github.com/xXBuilderBXx/DNetPlus/commit/02019b2bd1dcc277f80a26a426e7a45ab5d105f8)
   - Customize the version string from X.X.X to X.X.X (Custom DNetPlus)

- [Add sticker properties to messages](https://github.com/xXBuilderBXx/DNetPlus/commit/4565b38ece01b29c4ad8b21567ff2098201de330)
  - You can only get sticker messages, bots can not send stickers yet.

# Fixes/Tweaks by others
- [Limit request members batch size due to intents](https://github.com/xXBuilderBXx/DNetPlus/commit/0a68feaebb7b440c7e9393eaa3d6bfb8a8f00a87) from Discord.Net/pull/1647
   - Fixes an issue with downloading all guild members when using intents.

- [Rename and update guildembed to guildwidget](https://github.com/xXBuilderBXx/DNetPlus/commit/466b230e5501212eb1a7c9ba80f79b89c813c66d) from Discord.Net/pull/1573
   - Just some cleanup of old discord.net code.

- [Add missing guild properties](https://github.com/xXBuilderBXx/DNetPlus/commit/466b230e5501212eb1a7c9ba80f79b89c813c66d) from Discord.Net/pull/1573
   - Missing guild properties are for Discovery Splash, Rules channel, Max presence count, Max member count, Public updates channel, Approximate member count for online and current count using rest with the withCounts: true option.
   - Getting approximate member and presence count requires you to do GetGuildAsync(12345, withCounts: true)

- [Fix OperationCancelledException and thread blocking](https://github.com/xXBuilderBXx/DNetPlus/commit/308d73007533ef3d109d05a9b53c293fbe7270f5) from Discord.Net/pull/1562
   - Ignore operationcancelled exception in logs and less thread blocking.

- [Fix DM permissions not having add reactions](https://github.com/xXBuilderBXx/DNetPlus/commit/1bd3ea7d374b594edbaf33760ca26f4762a267bf) from Discord.Net/pull/1244
   - This has not been fixed in discord.net since January 2019.... untill now.

- [Add status and game on identify](https://github.com/xXBuilderBXx/DNetPlus/commit/15c23b2f70ffcaa8985b5a980832e57dd489f8f1) from Discord.Net/pull/1444
   - Allows you to set a status and game property on Client.StartAsync()

- [Add missing overwrite permissions](https://github.com/xXBuilderBXx/DNetPlus/commit/eb78a7a209dc09b311934a44a1292e07417a8fcb) from Discord.Net/pull/1642
   - Fixes some missing overwrite perms like priority voice and video.

- [Add view guild insights permission](https://github.com/xXBuilderBXx/DNetPlus/commit/482123ce3cac788b054f0554e771a15930848213) from Discord.Net/pull/1619

- [Add allowed mentions to webhooks](https://github.com/xXBuilderBXx/DNetPlus/commit/57d754a242150c1034c232b8885cab846928faad) from Discord.Net/pull/1602
- [Detect disallowed intents and add warning](https://github.com/xXBuilderBXx/DNetPlus/commit/a2dc20acf0064f3513b876806d1c672b8eb1dc0a) from Discord.Net/pull/1603
   - Without this fix the client would just keep reconnecting with disallowed intents.

- [Handle null prefered locale](https://github.com/xXBuilderBXx/DNetPlus/commit/26b4b1888ca0a3ab206d216639962e863a47d332) from Discord.Net/pull/1624
   - This only happens in rare cases but worth fix to not break guild stuff.

- [Fix websocket regex in some cases](https://github.com/xXBuilderBXx/DNetPlus/commit/d9d377630457d321d28007acd16bd0e1b63be93f) from Discord.Net/pull/1637

- [Allow UserUpdate to be invoked from GuildMemberUpdate](https://github.com/xXBuilderBXx/DNetPlus/commit/ada2fa72ae014a3496f1f13b39c8df7f79a37c66) from Discord.Net/pull/1623
   - This allows for some global changes like username/avatar to be fired from UserUpdate without the Presence Intent.

- [Add team properties to the application info](https://github.com/xXBuilderBXx/DNetPlus/commit/4aff5bb4646ddd0fce2973af13cb9b1232e5af1e) from Discord.Net/pull/1604

- [Add include roles option for guild prune users](https://github.com/xXBuilderBXx/DNetPlus/commit/9e6bea6ca8cfa52ff6ab615db526fc95a751685b) from Discord.Net/pull/1581
   - Allows you to select a list of roles to include in the prune users aside from just no roles.
