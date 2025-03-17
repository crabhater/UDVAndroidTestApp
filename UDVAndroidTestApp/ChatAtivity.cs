using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Adapters;
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
            _viewModel = chatViewModel;
            

            _messagesListView = FindViewById<ListView>(Resource.Id.messagesListView);
            _inputMessageEditText = FindViewById<EditText>(Resource.Id.inputMessageEditText);
            _sendButton = FindViewById<Button>(Resource.Id.sendButton);

            _messagesListView.Adapter = new MessagesAdapter(this, _viewModel.Messages);
        }
    }
}
