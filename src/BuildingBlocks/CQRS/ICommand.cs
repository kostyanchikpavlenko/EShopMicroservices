using System.Windows.Input;
using MediatR;

namespace BuildingBlocks.CQRS;
interface ICommand : ICommand<Unit>
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}