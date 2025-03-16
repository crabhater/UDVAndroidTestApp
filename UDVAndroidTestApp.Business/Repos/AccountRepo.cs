using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Base;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.App.Repos
{
    public class AccountRepo : RepositoryBase<Account>
    {
        public AccountRepo(IAppDataContext context) : base(context)
        {
        }

        public override async Task AddAsync(Account item, CancellationToken token)
        {
            await Context.Accounts.AddAsync(item, token);
        }

        public override Task AddRangeAsync(IEnumerable<Account> items, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Account item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Account> GetInstance()
        {
            return Context.Accounts;
        }

        public override Task<IEnumerable<Account>> GetInstanceAsync(Expression<Func<Account, bool>> predicate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateAsync(Account item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
