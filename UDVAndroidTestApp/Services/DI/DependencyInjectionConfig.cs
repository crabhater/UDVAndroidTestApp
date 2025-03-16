using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.ViewModels;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.DB;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.App.Repos;

namespace UDVAndroidTestApp.Services.DI
{
    public static class DependencyInjectionConfig
    {
        private static IServiceProvider serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get => serviceProvider ?? ConfigureServices();
        }
        
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ChatFolderViewModel>();
            services.AddTransient<ChatViewModel>();


            services.AddDbContext<IAppDataContext, AppDataContext>();
            services.AddSingleton<IRepositoryManager, RepositoryManager>();

            serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
