using System.Linq.Expressions;

namespace General.Repository
{
    public interface IGeneralRepository<T> where T : class
    {
        /// <summary>
        /// Inserts new record in a table.
        /// </summary>
        /// <param name="entity">Entity instace to be inserted</param>
        /// <returns>Inserted instance</returns>
        public Task<T> Insert(T entity);

        public Task<List<T>> FindAll(Expression<Func<T, bool>> predicate);

        public Task<T?> FindSingle(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Inserts multiple records in a table.
        /// </summary>
        /// <param name="entities"><c>List</c> of entity instances to be inserted</param>
        /// <returns></returns>
        public Task BatchInsert(IEnumerable<T> entities);

        /// <summary>
        /// Modifies multiple records in a table.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Modified list of modified entities</returns>
        public Task BatchUpdate(IEnumerable<T> entities);

        /// <summary>
        /// Modifies existing record in a table.
        /// </summary>
        /// <param name="entity">Entity instance to be modified</param>
        /// <returns>Modified instance</returns>
        public Task<T> Update(T entity);

        /// <summary>
        /// Deletes existing record in a table.
        /// </summary>
        /// <param name="entity">Entity instance to be deleted</param>
        /// <returns>Deleted instance</returns>
        public Task Delete(T entity);

        /// <summary>
        /// Deletes multiple records in a table.
        /// </summary>
        /// <param name="entities"><c>List</c> of entity instances to be deleted</param>
        public void BatchDelete(IEnumerable<T> entities);

        /// <summary>
        /// Get number of rows in database table.
        /// </summary>
        /// <returns>Row count of table</returns>
        public int Count();
    }
}