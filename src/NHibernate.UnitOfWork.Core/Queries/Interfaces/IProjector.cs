using NHibernate.Criterion;
using NHibernate.UnitOfWork.Core.Queries.Enums;
using System;
using System.Linq.Expressions;

namespace NHibernate.UnitOfWork.Core.Queries.Interfaces
{
    public interface IProjector
    {
        public string ColumnName { get; }
        public string AliasName { get; }
        public Expression<Func<object>> AliasPath { get; }
        public ProjectionType ProjectionType { get; }
        public bool IsColumnOrAlias { get; }

        IProjection GetProjection();
    }
}
