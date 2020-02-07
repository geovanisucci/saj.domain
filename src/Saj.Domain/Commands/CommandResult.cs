namespace Saj.Domain.Commands
{
    using System.Collections.Generic;
    using System.Net;
    using Flunt.Notifications;
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }


        public static CommandResult Succeeded(HttpStatusCode statusCode = 0, string message = null)
           => new CommandResult { Success = true, StatusCode = statusCode, Message = message };
        public static CommandResult Failed(HttpStatusCode statusCode = 0, string message = null, IReadOnlyCollection<Notification> notifications = null)
      => new CommandResult { Success = false, StatusCode = statusCode, Message = message, Notifications = notifications };
    }

    public class CommandResult<CommandResponse> : CommandResult
      where CommandResponse : ICommandResponse
    {
        public CommandResponse Value { get; set; }

        public static CommandResult<CommandResponse> Succeeded(CommandResponse value, HttpStatusCode statusCode = 0, string message = null)
       => new CommandResult<CommandResponse> { Value = value, Success = true, StatusCode = statusCode, Message = message };


        public static new CommandResult<CommandResponse> Succeeded(HttpStatusCode statusCode = 0, string message = null)
            => Succeeded(default(CommandResponse), statusCode, message);



        public static CommandResult<CommandResponse> Failed(CommandResponse value, HttpStatusCode statusCode = 0, string message = null, IReadOnlyCollection<Notification> notifications = null)
            => new CommandResult<CommandResponse> { Value = value, Success = false, StatusCode = statusCode, Message = message, Notifications = notifications };

        public static new CommandResult<CommandResponse> Failed(HttpStatusCode statusCode = 0, string message = null, IReadOnlyCollection<Notification> notifications = null)
    => Failed(default(CommandResponse), statusCode, message, notifications);
    }
}
