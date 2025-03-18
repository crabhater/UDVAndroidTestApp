using Android.App;
using Android.OS;
using Android.Widget;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Adapters;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using UDVAndroidTestApp.Events;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp
{
    [Activity(Label = "Чатик в радость")]
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

            var chatViewModel = serviceProvider.GetService<ChatViewModel>();
            chatViewModel.ChatId = Intent.GetIntExtra("ChatId", 0);
            WeakReferenceMessenger.Default.Send(new ChatMessageCreatedMessage());
            _viewModel = chatViewModel;
            

            _messagesListView = FindViewById<ListView>(Resource.Id.messagesListView);
            _inputMessageEditText = FindViewById<EditText>(Resource.Id.inputMessageEditText);
            _sendButton = FindViewById<Button>(Resource.Id.sendButton);

            _messagesListView.Adapter = new MessagesAdapter(this, _viewModel.Messages);

            _sendButton.Click += (sernder, e) =>
            {
                var text = _inputMessageEditText.Text;
                _viewModel.CreateMessage(text);
                _inputMessageEditText.Text = string.Empty;
            };
        }
        protected override void OnStop()
        {
            base.OnStop();
            _viewModel.EventsDelete();
        }
    }
}
