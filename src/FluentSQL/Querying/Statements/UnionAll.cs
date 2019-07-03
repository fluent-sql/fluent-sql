using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>UNION ALL</c>-statement for combining two queries, filtering out duplicates.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class UnionAllWithSameParameterTypes<TParameters, TQueryResult> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <inheritdoc />
        public UnionAllWithSameParameterTypes(
            QueryContext<TParameters, TQueryResult> queryContext,
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
            : base(queryContext)
        {
            First = first;
            Second = second;
        }

        internal override void Parse(QueryParser<TParameters, TQueryResult> parser)
        {
            parser.UnionAll(First, Second);
        }

        private QueryComponent<TParameters, TQueryResult> First { get; }
        private QueryComponent<TParameters, TQueryResult> Second { get; }
    }

    /// <summary>
    ///     The <c>UNION ALL</c>-statement for combining two queries, filtering out duplicates.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class UnionAllNoParametersWithParameter<TParameters, TQueryResult> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <inheritdoc />
        public UnionAllNoParametersWithParameter(
            QueryContext<TParameters, TQueryResult> queryContext,
            QueryComponent<NoParameters, TQueryResult> first,
            QueryComponent<TParameters, TQueryResult> second)
            : base(queryContext)
        {
            First = first;
            Second = second;
        }

        internal override void Parse(QueryParser<TParameters, TQueryResult> parser)
        {
            parser.UnionAll(First, Second);
        }

        private QueryComponent<NoParameters, TQueryResult> First { get; }
        private QueryComponent<TParameters, TQueryResult> Second { get; }
    }

    /// <summary>
    ///     The <c>UNION ALL</c>-statement for combining two queries, filtering out duplicates.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class UnionAllParameterWithNoParameter<TParameters, TQueryResult> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <inheritdoc />
        public UnionAllParameterWithNoParameter(
            QueryContext<TParameters, TQueryResult> queryContext,
            QueryComponent<TParameters, TQueryResult> first,
            QueryComponent<NoParameters, TQueryResult> second)
            : base(queryContext)
        {
            First = first;
            Second = second;
        }

        internal override void Parse(QueryParser<TParameters, TQueryResult> parser)
        {
            parser.UnionAll(First, Second);
        }

        private QueryComponent<TParameters, TQueryResult> First { get; }
        private QueryComponent<NoParameters, TQueryResult> Second { get; }
    }
}
