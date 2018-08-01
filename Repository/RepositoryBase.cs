using Contracts.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly RepositoryContext _repositoryContext;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

        /// <inheritdoc />
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);

        /// <inheritdoc />
        /// <summary>
        /// Finds the specified record that matches expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> expression)
        {
            return FindByCondition(expression).DefaultIfEmpty(new T()).FirstOrDefault();
        }

        /// <inheritdoc />
        /// <summary>
        /// Finds all records.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll() => _repositoryContext.Set<T>();

        /// <inheritdoc />
        /// <summary>
        /// Finds records by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => _repositoryContext.Set<T>().Where(expression);

        /// <inheritdoc />
        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save() => _repositoryContext.SaveChanges();

        /// <inheritdoc />
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
    }
}