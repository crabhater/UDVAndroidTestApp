using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UDVAndroidTestApp.App.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Searh items in database forced by IDBEquatable comparer
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetInstance();

        /// <summary>
        /// Searh items in database forced by IDBEquatable comparer
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetInstanceAsync(Expression<Func<T, bool>> predicate, CancellationToken token);

        /// <summary>
        /// Execute insert statement on item
        /// </summary>
        /// <param name="item">Item to add</param>
        Task AddAsync(T item, CancellationToken token);

        /// <summary>
        /// Execute insert statement on items array
        /// </summary>
        /// <param name="items">Items to add</param>
        Task AddRangeAsync(IEnumerable<T> items, CancellationToken token);

        /// <summary>
        /// Remove item from database
        /// </summary>
        /// <param name="predicate"></param>
        Task DeleteAsync(T item, CancellationToken token);

        /// <summary>
        /// Update current object in database
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T item, CancellationToken token);


    }
}
