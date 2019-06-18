using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class Subquery<TQueryResult>
    {
        public Subquery(Expression<Func<Query<TQueryResult>>> query)
        {
            Query = query;
        }

        private Expression<Func<Query<TQueryResult>>> Query { get; }

        public TQueryResult QueryResult
        {
            get { return default(TQueryResult); }
        }
    }

    public class Subquery<TParameters, TQueryResult> where TParameters : new()
    {
        public Subquery(Expression<Func<Query<TParameters, TQueryResult>>> query)
        {
            Query = query;
        }

        private Expression<Func<Query<TParameters, TQueryResult>>> Query { get; }

        public TQueryResult QueryResult
        {
            get { return default(TQueryResult); }
        }
    }
}
