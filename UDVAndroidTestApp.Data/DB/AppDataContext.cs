using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Data.DB
{
    public class AppDataContext : DbContext, IAppDataContext
    {
        public DbSet<Participant> Accounts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages {  get; set; }
        public DbSet<User> Users { get; set; }

        
        public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
        {
            if (Database.EnsureCreated())
            {
                throw new InvalidOperationException();
            }

            //var users = new List<User>()
            //{
            //    new User() { Description = "Хороший парень", Name = "Вадим" },
            //    new User() { Description = "Отличный товарищ", Name = "Кирилл" },
            //    new User() { Description = "Болтушка", Name = "Елизавета" },
            //    new User() { Description = "Мега спец", Name = "Антон" },
            //};
            //Users.AddRange(users);
            //SaveChanges();

        }

        
        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "appdata.db");
            
            
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
