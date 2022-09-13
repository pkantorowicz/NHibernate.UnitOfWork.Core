using NHibernate.Criterion;
using NHibernate.UnitOfWork.Core.Exceptions;
using NHibernate.UnitOfWork.Core.Queries.Enums;
using NHibernate.UnitOfWork.Core.Queries.Interfaces;
using System;
using System.Linq.Expressions;

namespace NHibernate.UnitOfWork.Core.Queries
{
    internal class Projector : IProjector
    {
        private Projector(string columnName, string aliasName, Expression<Func<object>> aliasPath, ProjectionType projectionType)
        {
            ColumnName = columnName;
            AliasName = aliasName;
            AliasPath = aliasPath;
            ProjectionType = projectionType;
            IsColumnOrAlias = !string.IsNullOrEmpty(columnName);
        }

        public string ColumnName { get; }
        public string AliasName { get; }
        public Expression<Func<object>> AliasPath { get; }
        public ProjectionType ProjectionType { get; }
        public bool IsColumnOrAlias { get; }

        public static IProjector Project(string columnName, ProjectionType type = ProjectionType.Property)
        {
            return new Projector(columnName, columnName, null, type);
        }

        public static IProjector Project(string columnName, string aliasName, ProjectionType type = ProjectionType.Property)
        {
            return new Projector(columnName, aliasName, null, type);
        }

        public static IProjector Project(Expression<Func<object>> aliasPath, string aliasName,
            ProjectionType type = ProjectionType.Property)
        {
            return new Projector(null, aliasName, aliasPath, type);
        }

        public IProjection GetProjection()
        {
            return ProjectionType switch
            {
                ProjectionType.Avg => IsColumnOrAlias ? Projections.Avg(ColumnName) : Projections.Avg(AliasName),
                ProjectionType.Count => IsColumnOrAlias ? Projections.Count(ColumnName) : Projections.Count(AliasName),
                ProjectionType.Max => IsColumnOrAlias ? Projections.Max(ColumnName) : Projections.Max(AliasName),
                ProjectionType.Min => IsColumnOrAlias ? Projections.Min(ColumnName) : Projections.Min(AliasName),
                ProjectionType.RowCount => Projections.RowCount(),
                ProjectionType.Sum => IsColumnOrAlias ? Projections.Sum(ColumnName) : Projections.Sum(AliasName),
                ProjectionType.Property => IsColumnOrAlias ? Projections.Property(ColumnName) : Projections.Property(AliasName),
                _ or ProjectionType.None => 
                    throw new UnsupportedProjectionException(
                        "Provided projection is unsupported.",
                        ProjectionType.ToString(),
                        "102")
            };
        }
    }
}
