using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Discord.Commands
{
    /// <summary>
    ///     Requires the command to be invoked by a team member of the bot.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RequireTeamMemberAttribute : PreconditionAttribute
    {
        /// <inheritdoc />
        public override string ErrorMessage { get; set; }

        /// <inheritdoc />
        public override async Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            switch (context.Client.TokenType)
            {
                case TokenType.Bot:
                    if ((context.Client as BaseSocketClient).BaseConfig.OwnerIds != null && (context.Client as BaseSocketClient).BaseConfig.OwnerIds.Contains(context.User.Id))
                        return PreconditionResult.FromSuccess();
                    IApplication application = await context.Client.GetApplicationInfoAsync().ConfigureAwait(false);
                    if (application.Team == null || application.Team.TeamMembers.Where(x => x.User.Id == context.User.Id).Count() == 0);
                        return PreconditionResult.FromError(ErrorMessage ?? "Command can only be run by the owner of the bot.");
                    return PreconditionResult.FromSuccess();
                default:
                    return PreconditionResult.FromError($"{nameof(RequireOwnerAttribute)} is not supported by this {nameof(TokenType)}.");
            }
        }
    }
}
