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
    public class AccountRepo : RepositoryBase<Participant>
    {
        public AccountRepo(IAppDataContext context) : base(context)
        {
        }

        public override async Task AddAsync(Participant item, CancellationToken token)
        {
            await Context.Accounts.AddAsync(item, token);
            await Context.SaveChangesAsync();
        }

        public override Task AddRangeAsync(IEnumerable<Participant> items, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Participant item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Participant> GetInstance()
        {
            return Context.Accounts;
        }

        public override Task<IEnumerable<Participant>> GetInstanceAsync(Expression<Func<Participant, bool>> predicate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateAsync(Participant item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
