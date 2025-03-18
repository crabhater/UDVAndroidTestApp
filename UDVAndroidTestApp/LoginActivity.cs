using Android.Content;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp
{
    [Activity(Label = "Авторизация")]
    public class LoginActivity : Activity
    {
        private EditText loginEditText;
        private EditText passwordEditText;
        private Button loginButton;
        private LoginViewModel viewModel;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            var serviceProvider = DependencyInjectionConfig.ServiceProvider;
            viewModel = serviceProvider.GetService<LoginViewModel>();

            // Привязываем элементы UI
            loginEditText = FindViewById<EditText>(Resource.Id.loginEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            // Обработчик нажатия кнопки "Войти"
            loginButton.Click += async (sender, e) =>
            {
                // Передача значений в ViewModel
                viewModel.Login = loginEditText.Text;
                viewModel.Password = passwordEditText.Text;
                await viewModel.LoginAsync();

                // Переход на следующий экран
                var intent = new Intent(this, typeof(ChatFolderActivity));
                StartActivity(intent);
            };
        }
    }
}
