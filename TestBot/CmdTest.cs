using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestBot
{
    public class CmdTest : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task Test()
        {
           
            var WH = await (Context.Client.GetGuild(275054291360940032).GetTextChannel(772956282318880811) as SocketNewsChannel).FollowChannelAsync(Context.Channel as SocketTextChannel);
            if (WH == null)
                await ReplyAsync("Failed");
            else
                await ReplyAsync("Done");
        }

        [Command("testemote")]
        public async Task TestEmote([Remainder] string emote)
        {
            Console.WriteLine($"Test - {emote}");
            var e = Emoji.FromUnicode(emote);
            if (e == null)
                await ReplyAsync("Not valid");
            else
                await ReplyAsync("Valid");
        }

        [Command("getsticker")]
        public async Task GetMsg(ulong id)
        {
            Console.WriteLine("Get sticker");
            IMessage Msg = await Context.Channel.GetMessageAsync(id);
            if (Msg == null)
            {
                await ReplyAsync("Invalid message");
                return;
            }

            if (Msg.Stickers.Count() == 0)
            {
                await ReplyAsync("No sticker");
                return;
            }

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Msg.Stickers.First(), Newtonsoft.Json.Formatting.Indented));
        }

        [Command("replyto")]
        public async Task Replyto(ulong id)
        {
            Console.WriteLine("Testing");
            await Context.Channel.SendMessageAsync("Test", reference: new MessageReferenceParams { ChannelId = Context.Channel.Id, MessageId = id, GuildId = Context.Guild.Id });
        }

        [Command("embedimage")]
        public async Task EmbedImage(string image)
        {
            await Context.Channel.SendMessageAsync("", embed: new EmbedBuilder
            {
                ImageUrl = image
            }.Build());
        }

        [Command("testowner"), RequireOwner]
        public async Task TestOwner()
        {
            await ReplyAsync("Test owner");
        }
    }
}
