using Discord;
using Discord.API;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestBot
{
    public class CmdTest : ModuleBase<SocketCommandContext>
    {
        [Command("discovery")]
        public async Task Discovery()
        {
           
        }


        [Command("tget")]
        public async Task Test()
        {
            try
            {
                System.Collections.Generic.IReadOnlyCollection<Discord.Rest.RestGuildTemplate> Temps = await Context.Guild.GetTemplatesAsync();
                await ReplyAsync(Temps.Count.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Command("tcreate")]
        public async Task Create()
        {
            Discord.Rest.RestGuildTemplate ResGuildTemplate = await Context.Guild.CreateTemplateAsync("Test", "Test", true);
            if (ResGuildTemplate != null)
                await ReplyAsync(ResGuildTemplate.Code);
        }

        [Command("tsync")]
        public async Task Sync(string code)
        {
            await Context.Guild.SyncTemplateAsync(code);
        }

        [Command("tdelete")]
        public async Task Delete(string code)
        {
            await Context.Guild.DeleteTemplateAsync(code);
        }

        [Command("tmodify")]
        public async Task Modify(string code)
        {
            await Context.Guild.ModifyTemplateAsync(code, new Action<TemplateProperties>(x =>
            {
                x.Description = "YOLO";
            }));
        }

        [Command("testemote")]
        public async Task TestEmote([Remainder] string emote)
        {
            Console.WriteLine($"Test - {emote}");
            Emoji e = Emoji.FromUnicode(emote);
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
