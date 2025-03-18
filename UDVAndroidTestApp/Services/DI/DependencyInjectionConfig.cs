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
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.Services.DI
{
    /// <summary>
    /// Стандартный DI от майкрософтов
    /// </summary>
    public static class DependencyInjectionConfig
    {
        private static IServiceProvider serviceProvider;
        /// <summary>
        /// Все зависимоти тут
        /// </summary>
        public static IServiceProvider ServiceProvider
        {
            get => serviceProvider ?? ConfigureServices();
        }
        
        /// <summary>
        /// Регистрация зависимостей приложения, тут модели представлений, инфраструктурные элементы типа репозиториев 
        /// и контекст БД
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ChatFolderViewModel>();
            services.AddTransient<ChatViewModel>();
            services.AddTransient<ChatCreationViewModel>();
            services.AddTransient<UserCreationViewModel>();
            services.AddTransient<LoginViewModel>();


            services.AddDbContext<IAppDataContext, AppDataContext>();
            services.AddSingleton<IRepositoryManager, RepositoryManager>();
            services.AddSingleton<IImpersonateMgr, ImpersonateMgr>();

            serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
