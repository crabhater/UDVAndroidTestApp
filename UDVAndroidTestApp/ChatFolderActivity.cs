using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;
using static Android.Icu.Text.CaseMap;

namespace UDVAndroidTestApp
{
    [Activity(Label = "Список чатов")]
    public class ChatFolderActivity : Activity
    {
        private ChatFolderViewModel viewModel;
        private ListView chatsListView;
        private Button showOptionsButton;
        private Button addContactButton;
        private Button addChatButton;
        private bool optionsVisible;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            //Тащим из контейнера нужный viewmodel и вяжем к activity
            var serviceProvider = DependencyInjectionConfig.ServiceProvider;
            var chatFolderViewModel = serviceProvider.GetService<ChatFolderViewModel>();
            this.viewModel = chatFolderViewModel;

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chat_folder);

            chatsListView = FindViewById<ListView>(Resource.Id.chatListView);
            chatsListView.Adapter = new Adapters.ChatListAdapter(this, this.viewModel.Chats);
            
            showOptionsButton = FindViewById<Button>(Resource.Id.showOptionsButton);
            addContactButton = FindViewById<Button>(Resource.Id.addContactButton);
            addChatButton = FindViewById<Button>(Resource.Id.addChatButton);

            //Открытие чата по нажатию, перекинет в интерфейс чата
            chatsListView.ItemClick += (sender, e) =>
            {
                var selectedChat = viewModel.Chats[e.Position];
                var intent = new Intent(this, typeof(ChatActivity));
                intent.PutExtra("ChatId", selectedChat.Chat.Id); 
                StartActivity(intent);
            };


            //Управление отображением кнопок + анимация появления кнопок
            showOptionsButton.Click += (sender, e) =>
            {
                if (!optionsVisible)
                {
                    addChatButton.Visibility = Android.Views.ViewStates.Visible;
                    addContactButton.Visibility = Android.Views.ViewStates.Visible;
                    optionsVisible = true;
                }
                else
                {
                    addChatButton.Visibility = Android.Views.ViewStates.Gone;
                    addContactButton.Visibility = Android.Views.ViewStates.Gone;
                    optionsVisible = false;
                }
            };

            //Обработчик нажатия на кнопку добавления чата. Popup с текстбоксом и Y/N. Перекинет в интерфейс создания чата
            addChatButton.Click += (sender, e) =>
            {
                var title = string.Empty;
                var dialogRes = false;
                var input = new EditText(this);
                var dialog = new AlertDialog.Builder(this)
                    .SetTitle("Новый чат")
                    .SetView(input)
                    .SetPositiveButton("Добавить", (s, ev) =>
                    {
                        title = input.Text;
                        dialogRes = true;
                    })
                    .SetNegativeButton("Отмена", (s, ev) => { })
                    .Create();
                dialog.Show();

                dialog.DismissEvent += (sender, e) =>
                {
                    //Если нажали кнопку Добавить, идем в интерфейс создания чата + забираем название чата из popup
                    if (dialogRes)
                    {
                        var intent = new Intent(this, typeof(ChatCreationActivity));
                        intent.PutExtra("ChatTitle", title); 
                        StartActivity(intent);
                    }
                };
            };

            addContactButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(UserCreationActivity));
                StartActivity(intent);
            };
        }

        protected override void OnStop()
        {
            base.OnStop();
            viewModel.EventsDelete();
        }
        protected override void OnResume()
        {
            base.OnResume();
            viewModel.EventsDelete();
            viewModel.EventsInit();
        }

    }
}
