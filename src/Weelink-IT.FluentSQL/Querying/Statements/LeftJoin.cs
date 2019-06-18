﻿using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class LeftJoin<TParameters, TQueryResult, TTable> : Join<TParameters, TQueryResult, TTable> where TParameters : new()
    {
        public LeftJoin(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> child)
            : base(queryContext, child)
        {
        }
    }
}