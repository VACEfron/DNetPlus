using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestBot
{
    public class CmdTest : ModuleBase
    {
        [Command("test")]
        public async Task Test()
        {
            await ReplyAsync("Test");
        }

        [Command("testowner"), RequireOwner]
        public async Task TestOwner()
        {
            await ReplyAsync("Test owner");
        }
    }
}
