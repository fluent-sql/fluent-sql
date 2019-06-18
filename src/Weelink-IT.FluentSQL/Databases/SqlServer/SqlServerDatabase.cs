namespace WeelinkIT.FluentSQL.Databases.SqlServer
{
    /// <summary>
    ///     Represents a SQL Server database.
    /// </summary>
    public sealed class SqlServerDatabase : Database
    {
        /// <summary>
        ///     Construct a new database targeting SQL Server.
        /// </summary>
        public SqlServerDatabase()
            : base(new SqlServerQueryCompiler())
        {
        }
    }
}
