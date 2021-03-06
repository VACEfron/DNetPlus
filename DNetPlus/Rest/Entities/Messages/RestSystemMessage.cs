using System.Diagnostics;
using Model = Discord.API.Message;

namespace Discord.Rest
{
    /// <summary>
    ///     Represents a REST-based system message.
    /// </summary>
    [DebuggerDisplay(@"{DebuggerDisplay,nq}")]
    public class RestSystemMessage : RestMessage, ISystemMessage
    {
        /// <inheritdoc />
        public MessageType Type { get; private set; }

        internal RestSystemMessage(BaseDiscordClient discord, ulong id, IMessageChannel channel, IUser author)
            : base(discord, id, channel, author, MessageSource.System)
        {
        }
        internal new static RestSystemMessage Create(BaseDiscordClient discord, IMessageChannel channel, IUser author, Model model)
        {
            RestSystemMessage entity = new RestSystemMessage(discord, model.Id, channel, author);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);

            Type = model.Type;
        }

        private string DebuggerDisplay => $"{Author}: {Content} ({Id}, {Type})";
    }
}
