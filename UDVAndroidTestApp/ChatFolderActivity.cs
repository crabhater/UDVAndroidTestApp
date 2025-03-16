using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp
{
    [Activity(Label = "ChatFolderActivity")]
    public class ChatFolderActivity : Activity
    {
        private ChatFolderViewModel viewModel;
        private ListView listView;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            var serviceProvider = DependencyInjectionConfig.ServiceProvider;

            var chatFolderViewModel = serviceProvider.GetService<ChatFolderViewModel>();
            this.viewModel = chatFolderViewModel;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chat_folder);

            listView = FindViewById<ListView>(Resource.Id.chatListView);
            listView.Adapter = new Adapters.ChatListAdapter(this, this.viewModel.Chats);
        }
    }
}
