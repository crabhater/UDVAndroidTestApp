using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Base;
using UDVAndroidTestApp.Data.DB;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.App.Repos
{
    public class MessagesRepo : RepositoryBase<Message>
    {
        public MessagesRepo(IAppDataContext context) : base(context)
        {
        }

        public override async Task AddAsync(Message item, CancellationToken token)
        {
            var res = await Context.Messages.AddAsync(item, token);
            await Context.SaveChangesAsync();
        }

        public override Task AddRangeAsync(IEnumerable<Message> items, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Message item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Message> GetInstance()
        {
            return Context.Messages.Include(m => m.sender);
        }

        public override Task<IEnumerable<Message>> GetInstanceAsync(Expression<Func<Message, bool>> predicate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateAsync(Message item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
