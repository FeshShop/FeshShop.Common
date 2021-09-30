namespace FeshShop.Common.Mongo.Contracts
{
    using FeshShop.Common.Types;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
    }
}
