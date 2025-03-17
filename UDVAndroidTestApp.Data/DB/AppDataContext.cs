using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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

        //private readonly string _dbPath;
        public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
        {
            if (Database.EnsureCreated())
            {
                throw new InvalidOperationException();
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var folder = Environment.SpecialFolder.LocalApplicationData;
        //    var path = Environment.GetFolderPath(folder);
        //    var dbPath = System.IO.Path.Join(path, "Messages.db");
        //    optionsBuilder.UseSqlite($"Data Source = {dbPath}");
        //}

        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "appdata.db");
            
            // Убедимся, что директория существует
            var directory = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}").LogTo(Console.WriteLine, LogLevel.Information); ;
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
