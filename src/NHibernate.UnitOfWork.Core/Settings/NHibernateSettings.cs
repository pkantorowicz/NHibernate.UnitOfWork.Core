namespace NHibernate.UnitOfWork.Core;

public class NHibernateSettings
{
    public string ConnectionString { get; init; }
    public string Dialect { get; init; }
    public bool LogFormattedSql { get; init; }
    public bool LogSql { get; init; }
    public bool UseAuditTrail { get; set; }
}
