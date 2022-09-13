using NHibernate.UnitOfWork.Core.Entities;

namespace NHibernate.UnitOfWork.Core.Queries.Interfaces
{
    public interface IFilter<TEntity> where TEntity : class, IEntity
    {
        IQuery<TEntity> ToQuery(IQuery<TEntity> query);
    }
}
