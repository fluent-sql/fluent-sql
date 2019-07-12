using System;
using System.Linq.Expressions;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements;

#pragma warning disable 1591

namespace FluentSQL.Compilation.Parser
{
    public sealed class QueryParser
    {
        public QueryParser()
        {
            ResultNode = new AstNode();
        }

        internal AstNode Parse<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> queryContext)
        {
            queryContext.Parse(this);
            return ResultNode;
        }

        internal void Distinct()
        {
        }

        internal void From<TTable>(Expression<Func<TTable>> expression)
        {
            ResultNode.ChildNodes.Add(new FromNode());
        }

        internal void From<TTable>(Expression<Func<TTable>> expression, Alias alias)
        {
        }

        internal void GroupBy<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
        }

        internal void LeftJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
        }

        internal void LeftJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
        {
        }

        internal void RightJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
        }

        internal void RightJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
        {
        }

        internal void OuterJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
        }

        internal void OuterJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
        {
        }

        internal void Limit(int count)
        {
        }

        internal void OrderBy<TSqlExpression>(Expression<Func<TSqlExpression>> expression, SortDirection sortDirection)
        {
        }

        internal void Select<TSqlExpression>(Expression<Func<TSqlExpression>> expression, Alias alias)
        {
        }

        internal void Select<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
        }

        private void Union<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);
        }

        internal void Union<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
        {
            Union<TParameters, NoParameters, TQueryResult>(first, second);
        }

        internal void Union<TParameters, TQueryResult>(
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            Union<NoParameters, TParameters, TQueryResult>(first, second);
        }

        internal void Union<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            Union<TParameters, TParameters, TQueryResult>(first, second);
        }

        private void UnionAll<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);
        }

        internal void UnionAll<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
        {
            UnionAll<TParameters, NoParameters, TQueryResult>(first, second);
        }

        internal void UnionAll<TParameters, TQueryResult>(
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            UnionAll<NoParameters, TParameters, TQueryResult>(first, second);
        }

        internal void UnionAll<TParameters, TQueryResult>(
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
        {
            UnionAll<TParameters, TParameters, TQueryResult>(first, second);
        }

        internal void Where<TParameters>(Expression<Func<TParameters, bool>> expression)
        {
        }

        private AstNode ResultNode { get; }
    }
}
