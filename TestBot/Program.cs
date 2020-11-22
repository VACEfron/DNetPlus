﻿using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestBot
{
    public class Program
    {
        public static DiscordSocketClient Client;
        public static CommandService Commands;
        public static CommandHandler Handler;
        public static void Main(string[] args)
        {
            Start().GetAwaiter().GetResult();
        }
        public static async Task Start()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                OwnerIds = new ulong[] { 190590364871032834 },
                GatewayIntents = Discord.GatewayIntents.Guilds | Discord.GatewayIntents.GuildMessages | Discord.GatewayIntents.GuildMembers,
                AlwaysDownloadUsers = true
            });
            Client.Log += Client_Log;
            await Client.LoginAsync(Discord.TokenType.Bot, "NTQ3NDQzODkxMDQ2MDU1OTUw.XGwk2g.gNQHZ2uc_JvGcAJbSrtQ49fr278");
            await Client.StartAsync();
            Commands = new CommandService();
            Handler = new CommandHandler(Client, Commands);
            await Handler.InstallCommandsAsync();
            await Task.Delay(-1);
        }

        private static async Task Client_Log(Discord.LogMessage arg)
        {
            Console.WriteLine($"[{arg.Source}] {arg.Message}");
        }
    }
}
