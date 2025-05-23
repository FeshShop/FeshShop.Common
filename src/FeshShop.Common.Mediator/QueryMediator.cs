namespace FeshShop.Common.Mediator;

using Contracts.Query;
using System;
using System.Threading.Tasks;

public class QueryMediator(IServiceProvider serviceProvider) : IQueryMediator
{
    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        dynamic handler = serviceProvider.GetService(handlerType);

        return await handler.HandleAsync((dynamic)query);
    }
}