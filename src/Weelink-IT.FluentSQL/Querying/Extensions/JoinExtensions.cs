using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Statements;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class JoinExtensions
    {
        public static LeftJoin<TParameters, TQueryResult, TTable> LeftJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
            where TParameters : new()
            where TTable : Table
        {
            return new LeftJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }

        public static LeftJoin<TParameters, TQueryResult, TSubqueryResult> LeftJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
            where TParameters : new()
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new LeftJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        public static LeftJoin<TParameters, TQueryResult, TSubqueryResult> LeftJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
            where TParameters : new()
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new LeftJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        public static RightJoin<TParameters, TQueryResult, TTable> RightJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
            where TParameters : new()
        {
            return new RightJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }

        public static RightJoin<TParameters, TQueryResult, TSubqueryResult> RightJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
            where TParameters : new()
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new RightJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        public static RightJoin<TParameters, TQueryResult, TSubqueryResult> RightJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
            where TParameters : new()
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new RightJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        public static InnerJoin<TParameters, TQueryResult, TTable> InnerJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
            where TParameters : new()
        {
            return new InnerJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }

        public static InnerJoin<TParameters, TQueryResult, TSubqueryResult> InnerJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
            where TParameters : new()
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new InnerJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        public static InnerJoin<TParameters, TQueryResult, TSubqueryResult> InnerJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
            where TParameters : new()
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new InnerJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }
    }
}
