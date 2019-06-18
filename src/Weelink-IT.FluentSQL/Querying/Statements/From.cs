﻿using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class From<TParameters, TQueryResult, TTable> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        public From(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> table)
        {
            QueryContext = queryContext;
            Table = table;

            QueryContext.FromComponents.Add(this);
        }

        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TTable>> Table { get; }
    }
}