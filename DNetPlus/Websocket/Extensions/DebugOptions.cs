using System;

namespace Discord.WebSocket
{
    public class DiscordDebugConfig
    {
        public bool VoiceFix { get; set; }

        public DiscordDebugEvents Events { get; set; } 
    }
    public class DiscordDebugEvents
    {
        public bool DisableTyping { get; set; }
        public bool DisableInviteCreate { get; set; }
            public bool DisableInviteDelete { get; set; }
    }
}
