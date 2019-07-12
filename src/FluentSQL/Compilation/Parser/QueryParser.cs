using System;
using System.Linq.Expressions;

using FluentSQL.Modelling;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements;

#pragma warning disable 1591

namespace FluentSQL.Compilation.Parser
{
    public sealed class QueryParser
    {
        public QueryParser()
        {
            SelectNode = new SelectNode();
            ResultNode = SelectNode;
        }

        private AstNode ResultNode { get; set; }
        private SelectNode SelectNode { get; }

        internal AstNode Parse<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> queryContext)
            where TParameters : new()
        {
            queryContext.Parse(this);
            return ResultNode;
        }

        internal void Distinct()
        {
            SelectNode.Distinct.Distinct = true;
        }

        internal void From<TTable>(Expression<Func<TTable>> expression) where TTable : Table
        {
            throw new NotImplementedException();
        }

        internal void From<TTable>(Expression<Func<TTable>> expression, Alias alias) where TTable : Table
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
            SelectNode.Limit.Limit = count;
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

        private void Union<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
            where TFirstParameters : new()
            where TSecondParameters : new()
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);

            ResultNode = new UnionSetOperator(firstResult, secondResult);
        }

        internal void Union<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            Union<TParameters, NoParameters, TQueryResult>(first, second);
        }

        internal void Union<TParameters, TQueryResult>(
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            Union<NoParameters, TParameters, TQueryResult>(first, second);
        }

        internal void Union<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            Union<TParameters, TParameters, TQueryResult>(first, second);
        }

        private void UnionAll<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
            where TFirstParameters : new()
            where TSecondParameters : new()
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);

            ResultNode = new UnionAllSetOperator(firstResult, secondResult);
        }

        internal void UnionAll<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            UnionAll<TParameters, NoParameters, TQueryResult>(first, second);
        }

        internal void UnionAll<TParameters, TQueryResult>(
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            UnionAll<NoParameters, TParameters, TQueryResult>(first, second);
        }

        internal void UnionAll<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            UnionAll<TParameters, TParameters, TQueryResult>(first, second);
        }

        internal void Where<TParameters>(Expression<Func<TParameters, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
