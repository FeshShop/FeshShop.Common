namespace FeshShop.Common.Mediator;

using Contracts.Command;
using System;
using System.Threading.Tasks;

internal class CommandMediator(IServiceProvider serviceProvider) : ICommandMediator
{
    public async Task SendAsync<TModel>(TModel model) where TModel : ICommand
    {
        var handlerType = typeof(ICommandHandler<TModel>);
        dynamic handle = serviceProvider.GetService(handlerType);

        await handle.HandleAsync(model);
    }
}