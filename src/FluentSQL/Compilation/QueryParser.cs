﻿using System;
using System.Linq.Expressions;

using FluentSQL.Modelling;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements;
#pragma warning disable 1591

namespace FluentSQL.Compilation
{
    public sealed class QueryParser<TParameters, TQueryResult>  where TParameters : new()
    {
        public QueryParser()
        {
            RootNode = new Node();
        }

        internal void Distinct()
        {
            throw new NotImplementedException();
        }

        internal void From<TTable>(Expression<Func<TTable>> expression) where TTable : Table
        {
            throw new NotImplementedException();
        }

        internal void GroupBy<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
            throw new NotImplementedException();
        }

        internal void LeftJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        internal void LeftJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
        {
            throw new NotImplementedException();
        }

        internal void RightJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        internal void RightJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
        {
            throw new NotImplementedException();
        }

        internal void OuterJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        internal void OuterJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
        {
            throw new NotImplementedException();
        }

        internal void Limit(int count)
        {
            throw new NotImplementedException();
        }

        internal void OrderBy<TSqlExpression>(Expression<Func<TSqlExpression>> expression, SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }

        internal void Select<TSqlExpression>(Expression<Func<TSqlExpression>> expression, Alias alias)
        {
            throw new NotImplementedException();
        }

        internal void Select<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
            throw new NotImplementedException();
        }

        internal void Union<TFirstParameters, TSecondParameters>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second) 
            where TFirstParameters : new()
            where TSecondParameters : new()
        {
            var firstParser = new QueryParser<TFirstParameters, TQueryResult>();
            var secondParser = new QueryParser<TSecondParameters, TQueryResult>();

            first.QueryContext.Parse(firstParser);
            second.QueryContext.Parse(secondParser);

            RootNode = new Union(firstParser.RootNode, secondParser.RootNode);
        }

        internal void Union(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
        {
            Union<TParameters, NoParameters>(first, second);
        }

        internal void Union(
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            Union<NoParameters, TParameters>(first, second);
        }
        
        internal void Union(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            Union<TParameters, TParameters>(first, second);
        }

        internal void UnionAll<TFirstParameters, TSecondParameters>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second) 
            where TFirstParameters : new()
            where TSecondParameters : new()
        {
            var firstParser = new QueryParser<TFirstParameters, TQueryResult>();
            var secondParser = new QueryParser<TSecondParameters, TQueryResult>();

            first.QueryContext.Parse(firstParser);
            second.QueryContext.Parse(secondParser);

            RootNode = new UnionAll(firstParser.RootNode, secondParser.RootNode);
        }

        internal void UnionAll(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
        {
            UnionAll<TParameters, NoParameters>(first, second);
        }

        internal void UnionAll(
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            UnionAll<NoParameters, TParameters>(first, second);
        }
        
        internal void UnionAll(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            UnionAll<TParameters, TParameters>(first, second);
        }

        internal void Where(Expression<Func<TParameters, bool>> expression)
        {
            throw new NotImplementedException();
        }
 
        public Node RootNode { get; private set; }
    }
}
