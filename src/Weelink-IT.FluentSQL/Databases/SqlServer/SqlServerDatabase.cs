namespace WeelinkIT.FluentSQL.Databases.SqlServer
{
    /// <summary>
    ///     Represents a SQL Server database.
    /// </summary>
    public sealed class SqlServerDatabase : Database
    {
        public SqlServerDatabase()
            : base(new SqlServerQueryCompiler())
        {
        }
    }
}
