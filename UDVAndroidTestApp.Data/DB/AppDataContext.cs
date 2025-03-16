using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Data.DB
{
    public class AppDataContext : DbContext, IAppDataContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages {  get; set; } 

        private readonly string _dbPath;
        public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
        {
            Database.EnsureCreated();
            SaveChangesAsync();
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            _dbPath = System.IO.Path.Join(path, "Messages.db");
        }
    }
}
