using NHibernate.UnitOfWork.Core.Entities;

namespace NHibernate.UnitOfWork.Core.Queries.Interfaces
{
    public interface IQuery<TEntity> : IQueryOver<TEntity, TEntity>
        where TEntity : class, IEntity
    {
    }
}
