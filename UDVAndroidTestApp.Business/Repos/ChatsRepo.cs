using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Base;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Data.DB;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.App.Repos
{
    public class ChatsRepo : RepositoryBase<Chat>
    {
        public ChatsRepo(IAppDataContext context) : base(context) { }

        public override async Task AddAsync(Chat item, CancellationToken token)
        {
            await Context.Chats.AddAsync(item, token);
        }

        public override Task AddRangeAsync(IEnumerable<Chat> items, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Chat item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Chat> GetInstance()
        {
            return Context.Chats;
        }

        public override Task<IEnumerable<Chat>> GetInstanceAsync(Expression<Func<Chat, bool>> predicate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateAsync(Chat item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
