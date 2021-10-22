﻿namespace FeshShop.Common.Mongo.Contracts
{
    using FeshShop.Common.Types;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
