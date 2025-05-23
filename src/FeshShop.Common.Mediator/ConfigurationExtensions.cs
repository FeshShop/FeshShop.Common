namespace FeshShop.Common.Mediator;

using Contracts.Command;
using Contracts.Query;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services) 
        => services
            .AddTransient<IMediator, Mediator>()
            .AddTransient<IQueryMediator, QueryMediator>()
            .AddTransient<ICommandMediator, CommandMediator>();
}