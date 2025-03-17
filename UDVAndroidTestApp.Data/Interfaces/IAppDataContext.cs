
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Data.Interfaces
{
    public interface IAppDataContext
    {
        public DbSet<Participant> Accounts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        public Task<int> SaveChangesAsync();
    }
}
