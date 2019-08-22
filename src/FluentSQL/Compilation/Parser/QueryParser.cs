using System;
using System.Linq.Expressions;

using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Extensions;
using FluentSQL.Modelling;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements;

namespace FluentSQL.Compilation.Parser
{
    public sealed class QueryParser
    {
        public QueryParser()
        {
            ResultNode = new RootNode();
        }

        private AstNode ResultNode { get; set; }

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
            ResultNode.ChildNodes.Add(new FromNode(ResultNode));
        }

        internal void From<TTable>(Expression<Func<TTable>> expression, Alias alias)
        {
            ResultNode.ChildNodes.Add(new FromNode(ResultNode, alias.Name));
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

        internal void InnerJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<bool>> expression)
        {
        }

        internal void InnerJoin<TTable>(Expression<Func<TTable>> child, Expression<Func<TTable, bool>> expression)
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

        internal void OrderByAscending<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
        }

        internal void OrderByDescending<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
        }

        internal void Select<TSqlExpression>(Expression<Func<TSqlExpression>> expression, Alias alias)
        {
            Parse(new SelectComponentParser(), expression);
       
            var x = expression.Body.NodeType;
        }

        internal class SelectComponentParser : QueryComponentParser
        {
            public void ParseComponent<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
            {
            }

            public void ParseComponent<TExpressionType>(SqlExpression<TExpressionType> expression)
            {
            }
        }

        internal interface QueryComponentParser
        {
            void ParseComponent<TSqlExpression>(Expression<Func<TSqlExpression>> expression);
            void ParseComponent<TExpressionType>(SqlExpression<TExpressionType> expression);
        }

        private void Parse<TSqlExpression>(QueryComponentParser parser, Expression<Func<TSqlExpression>> expression)
        {
            dynamic dynamicParser = parser;

            if (expression.IsSqlExpression())
            {
                Func<TSqlExpression> compiled = expression.Compile();
                TSqlExpression result = compiled();
                dynamicParser.ParseComponent(result);
            }
            else
            {
                dynamicParser.ParseComponent(expression);
            }
        }

        internal void Select<TSqlExpression>(Expression<Func<TSqlExpression>> expression)
        {
            Parse(new SelectComponentParser(), expression);
       
            var x = expression.Body.NodeType;
        }

        internal void Union<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            (AstNode firstResult, AstNode secondResult) = ParseMultiple(first, second);

            ResultNode = new UnionNode(firstResult, secondResult);
        }

        internal void UnionAll<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            (AstNode firstResult, AstNode secondResult) = ParseMultiple(first, second);

            ResultNode = new UnionAllNode(firstResult, secondResult);
        }

        private (AstNode firstResult, AstNode secondResult) ParseMultiple<TFirstParameters, TSecondParameters, TQueryResult>(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
        {
            var firstParser = new QueryParser();
            AstNode firstResult = firstParser.Parse(first.QueryContext);

            var secondParser = new QueryParser();
            AstNode secondResult = secondParser.Parse(second.QueryContext);

            return (firstResult, secondResult);
        }

        internal void Where<TParameters>(Expression<Func<TParameters, bool>> expression)
        {
        }
    }
}
