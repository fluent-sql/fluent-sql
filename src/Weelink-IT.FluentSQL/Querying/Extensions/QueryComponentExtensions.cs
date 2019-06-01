﻿using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="QueryComponent{TModel, TParameters, TResult}" />.
    /// </summary>
    public static class QueryComponentExtensions
    {
        /// <summary>
        ///     Compile the <see cref="QueryContext{TModel, TParameters, TResult}" /> associated with
        ///     this <see cref="QueryComponent{TModel, TParameters, TResult}" /> into a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <param name="component">The <see cref="QueryComponent{TModel, TParameters, TResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TParameters, TResult}" />.</returns>
        public static Query<TParameters, TResult> Compile<TModel, TParameters, TResult>(
            this QueryComponent<TModel, TParameters, TResult> component)
            where TModel : PersistenceModel
            where TParameters : new()
        {
            return component.QueryContext.Compile();
        }

        /// <summary>
        ///     Compile the  <see cref="QueryContext{TModel, TParameters, TResult}">QueryContext&lt;Model, TResult&gt;</see> associated with
        ///     this <see cref="QueryComponent{TModel, TParameters, TResult}">QueryComponent&lt;Model, TResult&gt;</see> into a
        ///     <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <param name="component">The  <see cref="QueryComponent{TModel, TParameters, TResult}">QueryComponent&lt;Model, TResult&gt;</see> to compile.</param>
        /// <returns>A compiled <see cref="Query{TParameters, TResult}" />.</returns>
        public static Query<TResult> Compile<TModel, TResult>(
            this QueryComponent<TModel, NoParameters, TResult> component)
            where TModel : PersistenceModel
        {
            return component.QueryContext.Compile();
        }
    }
}
