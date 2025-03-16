using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Data.DB;
using UDVAndroidTestApp.Data.Interfaces;

namespace UDVAndroidTestApp.App.Base
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        protected IAppDataContext Context;
        protected RepositoryBase(IAppDataContext context)
        {
            Context = context;
        }
        public abstract Task AddAsync(T item, CancellationToken token);

        public abstract Task AddRangeAsync(IEnumerable<T> items, CancellationToken token);

        public abstract Task DeleteAsync(T item, CancellationToken token);

        public abstract IQueryable<T> GetInstance();

        public abstract Task<IEnumerable<T>> GetInstanceAsync(Expression<Func<T, bool>> predicate, CancellationToken token);

        public abstract Task<bool> UpdateAsync(T item, CancellationToken token);
    }
}
