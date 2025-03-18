using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp;

[Activity(Label = "Создание юзера")]
public class UserCreationActivity : Activity
{
    private UserCreationViewModel viewModel;
    private EditText _nameEditText;
    private EditText _descrEditText;
    private Button _createButton;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.create_user);

        var serviceProvider = DependencyInjectionConfig.ServiceProvider;
        viewModel = serviceProvider.GetService<UserCreationViewModel>();


        _nameEditText = FindViewById<EditText>(Resource.Id._nameEditText);
        _descrEditText = FindViewById<EditText>(Resource.Id._descrEditText);
        _createButton = FindViewById<Button>(Resource.Id.createButton);

        _createButton.Click += (sender, e) =>
        {
            viewModel.userName = _nameEditText.Text;
            viewModel.UserDescr = _descrEditText.Text;

            viewModel.CreateUserCommand.Execute(null);


            Toast.MakeText(this, $"Юзер {_nameEditText.Text} создан!", ToastLength.Short).Show();
            Finish();
        };
    }

    
}