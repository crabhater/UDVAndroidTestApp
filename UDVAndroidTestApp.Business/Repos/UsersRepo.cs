using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Base;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Interfaces;

namespace UDVAndroidTestApp.App.Repos
{
    public class UsersRepo : RepositoryBase<User>
    {
        public UsersRepo(IAppDataContext context) : base(context)
        {
        }

        public override async Task AddAsync(User item, CancellationToken token)
        {
            await Context.Users.AddAsync(item, token);
            await Context.SaveChangesAsync();
        }

        public override async Task AddRangeAsync(IEnumerable<User> items, CancellationToken token)
        {
            await Context.Users.AddRangeAsync(items, token);
            await Context.SaveChangesAsync();
        }

        public override Task DeleteAsync(User item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<User> GetInstance()
        {
            return Context.Users;
        }

        public override Task<IEnumerable<User>> GetInstanceAsync(Expression<Func<User, bool>> predicate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateAsync(User item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
