using Saj.Domain.Commands;

namespace Saj.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}