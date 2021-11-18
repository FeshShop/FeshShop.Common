namespace FeshShop.Common.Mediator
{
    using FeshShop.Common.Mediator.Contracts;
    using FeshShop.Common.Mediator.Types;
    using System;
    using System.Threading.Tasks;

    public class CommandMediator : ICommandMediator
    {
        private readonly IServiceProvider serviceProvider;

        public CommandMediator(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public async Task SendAsync<TModel>(TModel model) where TModel : ICommand
        {
            var handlerType = typeof(ICommandHandler<TModel>);
            dynamic handle = serviceProvider.GetService(handlerType);

            await handle.HandleAsync(model);
        }
    }
}
