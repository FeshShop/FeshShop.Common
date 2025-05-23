namespace FeshShop.Common.Mediator.Contracts.Command;

public interface ICommandMediator
{
    public Task SendAsync<TModel>(TModel model) where TModel : ICommand;
}