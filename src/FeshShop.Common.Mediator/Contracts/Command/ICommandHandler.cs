namespace FeshShop.Common.Mediator.Contracts.Command;

public interface ICommandHandler<in TModel>
{
    Task HandleAsync(TModel model);
}