using NHibernate.Cfg.Loquacious;
using NHibernate.Dialect;
using NHibernate.UnitOfWork.Core.Exceptions;

namespace NHibernate.UnitOfWork.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void SetDialect(this DbIntegrationConfigurationProperties dbConfiguration, string dialect)
        {
            var fixedDialogName = dialect.ToLowerInvariant();

            switch (fixedDialogName)
            {
                case "mssql2012dialect":
                    dbConfiguration.Dialect<MsSql2012Dialect>();
                    break;
                case "mssql2008dialect":
                    dbConfiguration.Dialect<MsSql2008Dialect>();
                    break;
                case "mssqlazure2008dialect":
                    dbConfiguration.Dialect<MsSqlAzure2008Dialect>();
                    break;
                case "mssql2005dialect":
                    dbConfiguration.Dialect<MsSql2005Dialect>();
                    break;
                case "mssql2000dialect":
                    dbConfiguration.Dialect<MsSql2000Dialect>();
                    break;
                case "mssql7dialect":
                    dbConfiguration.Dialect<MsSql7Dialect>();
                    break;
                case "mssqlce40dialect":
                    dbConfiguration.Dialect<MsSqlCe40Dialect>();
                    break;
                case "mssqlcedialect":
                    dbConfiguration.Dialect<MsSqlCeDialect>();
                    break;
                case "oracle12cdialect":
                    dbConfiguration.Dialect<Oracle12cDialect>();
                    break;
                case "oracle10gdialect":
                    dbConfiguration.Dialect<Oracle10gDialect>();
                    break;
                case "oracle9idialect":
                    dbConfiguration.Dialect<Oracle9iDialect>();
                    break;
                case "oracle8idialect":
                    dbConfiguration.Dialect<Oracle8iDialect>();
                    break;
                case "oraclelitedialect":
                    dbConfiguration.Dialect<OracleLiteDialect>();
                    break;
                case "mysql55dialect":
                    dbConfiguration.Dialect<MySQL55Dialect>();
                    break;
                case "mysql5dialect":
                    dbConfiguration.Dialect<MySQL5Dialect>();
                    break;
                case "mysql55innodbdialect":
                    dbConfiguration.Dialect<MySQL55InnoDBDialect>();
                    break;
                case "mysql5innodbdialect":
                    dbConfiguration.Dialect<MySQL5InnoDBDialect>();
                    break;
                case "mysqldialect":
                    dbConfiguration.Dialect<MySQLDialect>();
                    break;
                case "postgreSQLdialect":
                    dbConfiguration.Dialect<PostgreSQLDialect>();
                    break;
                case "postgresql81dialect":
                    dbConfiguration.Dialect<PostgreSQL81Dialect>();
                    break;
                case "postgresql82dialect":
                    dbConfiguration.Dialect<PostgreSQL82Dialect>();
                    break;
                case "postgresql83dialect":
                    dbConfiguration.Dialect<PostgreSQL83Dialect>();
                    break;
                case "db2dialect":
                    dbConfiguration.Dialect<DB2Dialect>();
                    break;
                case "db2400dialect":
                    dbConfiguration.Dialect<DB2400Dialect>();
                    break;
                case "informixdialect":
                    dbConfiguration.Dialect<InformixDialect>();
                    break;
                case "informixdialect0940":
                    dbConfiguration.Dialect<InformixDialect0940>();
                    break;
                case "informixdialect1000":
                    dbConfiguration.Dialect<InformixDialect1000>();
                    break;
                case "sybaseasa9dialect":
                    dbConfiguration.Dialect<SybaseASA9Dialect>();
                    break;
                case "sybasease15dialect":
                    dbConfiguration.Dialect<SybaseASE15Dialect>();
                    break;
                case "sybasesqlanywhere10dialect":
                    dbConfiguration.Dialect<SybaseSQLAnywhere10Dialect>();
                    break;
                case "sybasesqlanywhere11dialect":
                    dbConfiguration.Dialect<SybaseSQLAnywhere11Dialect>();
                    break;
                case "sybasesqlanywhere12dialect":
                    dbConfiguration.Dialect<SybaseSQLAnywhere12Dialect>();
                    break;
                case "firebirddialect":
                    dbConfiguration.Dialect<FirebirdDialect>();
                    break;
                case "sqlitedialect":
                    dbConfiguration.Dialect<SQLiteDialect>();
                    break;
                case "ingresdialect":
                    dbConfiguration.Dialect<IngresDialect>();
                    break;
                case "ingres9dialect":
                    dbConfiguration.Dialect<Ingres9Dialect>();
                    break;
                default:
                    throw new UnsupportedDialectException(
                        "Provided dialect is unsupported.",
                        dialect,
                        "101");
            }
        }
    }
}