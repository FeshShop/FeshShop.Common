namespace FeshShop.Common.Types;

using MongoDB.Bson.Serialization.Attributes;
using System;

public abstract class BaseEntity : IIdentifiable
{
    protected BaseEntity(Guid id)
    {
        Id = id;
        CreatedDate = DateTime.UtcNow;
        SetUpdatedDate();
    }

    [BsonId]
    public Guid Id { get; protected set; }

    public DateTime CreatedDate { get; protected set; }

    public DateTime UpdatedDate { get; protected set; }

    protected virtual void SetUpdatedDate() => UpdatedDate = DateTime.UtcNow;
}