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
            ResultNode.ChildNodes.Add(new FromNode(null));
        }

        internal void From<TTable>(Expression<Func<TTable>> expression, Alias alias)
        {
            ResultNode.ChildNodes.Add(new FromNode(alias.Name));
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

        internal void Union<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);

            ResultNode = new UnionNode(firstResult, secondResult);
        }

        internal void UnionAll<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);

            ResultNode = new UnionAllNode(firstResult, secondResult);
        }

        internal void Where<TParameters>(Expression<Func<TParameters, bool>> expression)
        {
        }

        private AstNode ResultNode { get; set; }
    }
}
