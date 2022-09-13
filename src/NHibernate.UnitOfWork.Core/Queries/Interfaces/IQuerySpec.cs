using NHibernate.Transform;
using NHibernate.UnitOfWork.Core.Entities;
using System.Collections.Generic;

namespace NHibernate.UnitOfWork.Core.Queries.Interfaces
{
    public interface IQuerySpec<TEntity> where TEntity : class, IEntity 
    {
        IFilter<TEntity> Filter { get; }
        IReadOnlyCollection<ISorter<TEntity>> Sorters { get; }
        IReadOnlyCollection<IProjector> SpecificFields { get; }
        IResultTransformer UseCustomTransformer { get; }

        IQueryOver<TEntity> BuildSpecification();
    }
}
