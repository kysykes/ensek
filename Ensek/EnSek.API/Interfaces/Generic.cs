using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnSek.API.Interfaces
{
    public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse: IResponse
    {
        Task<TResponse> HandleAsync(TCommand command);
    }

    public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
    {
        Task<string> HandleAsync(TCommand command);
    }

    public interface ICommand<TResponse> where TResponse : IResponse
    {
    }
    public interface ICommand
    {
    }

    public interface IResponse
    {
        List<string> Errors { get; }
        string Message { get; }
    }
}