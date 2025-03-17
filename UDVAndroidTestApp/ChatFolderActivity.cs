using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp
{
    [Activity(Label = "Список чатов")]
    public class ChatFolderActivity : Activity
    {
        private ChatFolderViewModel viewModel;
        private ListView listView;
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

            listView = FindViewById<ListView>(Resource.Id.chatListView);
            listView.Adapter = new Adapters.ChatListAdapter(this, this.viewModel.Chats);

            showOptionsButton = FindViewById<Button>(Resource.Id.showOptionsButton);
            addContactButton = FindViewById<Button>(Resource.Id.addContactButton);
            addChatButton = FindViewById<Button>(Resource.Id.addChatButton);

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
                    //Если нажали кнопку Добавить, идем в интерфейс создания чата
                    if (dialogRes)
                    {
                        var intent = new Intent(this, typeof(ChatCreationActivity));
                        intent.PutExtra("ChatTitle", title); //Передаём название чата
                        StartActivity(intent);
                    }
                };
            };
        }
    }
}
