namespace FeshShop.Common.Mediator
{
    using FeshShop.Common.Mediator.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services) 
            => services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IQueryMediator, QueryMediator>()
                .AddTransient<ICommandMediator, CommandMediator>();
    }
}
