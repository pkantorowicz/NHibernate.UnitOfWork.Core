using NHibernate.UnitOfWork.Core.Entities;

namespace NHibernate.UnitOfWork.Core.Queries.Interfaces
{
    public interface ISorter<TEntity>
        where TEntity : class, IEntity
    {
        IQueryOver<TEntity> ApplyOrder(
            IQueryOver<TEntity> queryOverOrderBuilder,
            bool firstSort = true);
    }
}
