# Info
This is a fork of [Discord.net](https://github.com/discord-net/Discord.Net) v2.3.0-dev-20200904.2 with many tweaks and added functionality instead of waiting for months.

# Install
Remove any discord.net packages such as discord.net.commands, discord.net.websocket, discord.net.webhook and install the package from nuget with https://www.nuget.org/packages/DNetPlus

# Addons
You can install these optional addons to extend the functionality of DNetPlus.
- [Discord Interactive](https://www.nuget.org/packages/DNetPlus-Interactive) by [Foxbot](https://github.com/foxbot/Discord.Addons.Interactive) v2.2

# Fixes/Tweaks by me
- [Increase connection wait limit instead of timeouts](https://github.com/xXBuilderBXx/DNetPlus/commit/34e4cd07ea2147cf5fd449087a278567e14bb0b9)
  `This helps with bigger bots with 15+ shards to connect better.`


- [Make GetShardForId public](https://github.com/xXBuilderBXx/DNetPlus/commit/9e5d4b99f5061538db87ef316e54bddfc262fe32)
- [Allowed mentions property on modifymessage](https://github.com/xXBuilderBXx/DNetPlus/commit/506bab4e1af5b1c3960040e6125cc7b4ce3a34d0)
- [Ignore integration update events](https://github.com/xXBuilderBXx/DNetPlus/commit/f8c8387c277525d9488abb2a0671d45b7b585008)
- [Expose config for client and add ownerids override list for team/external users](https://github.com/xXBuilderBXx/DNetPlus/commit/faec9248120cf808de68996763459d00348192da)
> new DiscordSocketConfig { OwnerIds = new ulong[] { 190590364871032834 } };

# Fixes/Tweaks by others
- [Limit request members batch size due to intents](https://github.com/xXBuilderBXx/DNetPlus/commit/0a68feaebb7b440c7e9393eaa3d6bfb8a8f00a87) from Discord.Net/pull/1647
- [Rename and update guildembed to guildwidget](https://github.com/xXBuilderBXx/DNetPlus/commit/466b230e5501212eb1a7c9ba80f79b89c813c66d) from Discord.Net/pull/1573
- [Add missing guild properties](https://github.com/xXBuilderBXx/DNetPlus/commit/466b230e5501212eb1a7c9ba80f79b89c813c66d) from Discord.Net/pull/1573
> Missing guild properties are for Discovery Splash, Rules channel, Max presence count, Max member count, Public updates channel, Approximate member count for online and current count using rest with the withCounts: true option.
- [Fix OperationCancelledException and thread blocking](https://github.com/xXBuilderBXx/DNetPlus/commit/308d73007533ef3d109d05a9b53c293fbe7270f5) from Discord.Net/pull/1562
- [Fix DM permissions not having add reactions](https://github.com/xXBuilderBXx/DNetPlus/commit/1bd3ea7d374b594edbaf33760ca26f4762a267bf) from Discord.Net/pull/1244
- [Add status and game on identify](https://github.com/xXBuilderBXx/DNetPlus/commit/15c23b2f70ffcaa8985b5a980832e57dd489f8f1) from Discord.Net/pull/1444
- [Add missing overwrite permissions](https://github.com/xXBuilderBXx/DNetPlus/commit/eb78a7a209dc09b311934a44a1292e07417a8fcb) from Discord.Net/pull/1642
- [Add view guild insights permission](https://github.com/xXBuilderBXx/DNetPlus/commit/482123ce3cac788b054f0554e771a15930848213) from Discord.Net/pull/1619
- [Add allowed mentions to webhooks](https://github.com/xXBuilderBXx/DNetPlus/commit/57d754a242150c1034c232b8885cab846928faad) from Discord.Net/pull/1602
- [Detect disallowed intents and add warning](https://github.com/xXBuilderBXx/DNetPlus/commit/a2dc20acf0064f3513b876806d1c672b8eb1dc0a) from Discord.Net/pull/1603
- [Handle null prefered locale](https://github.com/xXBuilderBXx/DNetPlus/commit/26b4b1888ca0a3ab206d216639962e863a47d332) from Discord.Net/pull/1624
