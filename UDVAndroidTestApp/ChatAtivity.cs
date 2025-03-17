using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Adapters;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : Activity
    {
        private ChatViewModel _viewModel;
        private ListView _messagesListView;
        private EditText _inputMessageEditText;
        private Button _sendButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chat);
            var serviceProvider = DependencyInjectionConfig.ServiceProvider;

            // Пример: получение ViewModel из контейнера
            var chatViewModel = serviceProvider.GetService<ChatViewModel>();
            chatViewModel.ChatId = Intent.GetIntExtra("ChatId", 0);
            _viewModel = chatViewModel;
            _viewModel.Init();
            

            _messagesListView = FindViewById<ListView>(Resource.Id.messagesListView);
            _inputMessageEditText = FindViewById<EditText>(Resource.Id.inputMessageEditText);
            _sendButton = FindViewById<Button>(Resource.Id.sendButton);

            _messagesListView.Adapter = new MessagesAdapter(this, _viewModel.Messages);

            _sendButton.Click += (sernder, e) =>
            {
                var text = _inputMessageEditText.Text;
                _viewModel.CreateMessage(text);
            };
        }
    }
}
