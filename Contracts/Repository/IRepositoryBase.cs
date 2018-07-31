using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Contracts.Repository
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Finds all records.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Finds records by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Finds the specified record that matches expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}