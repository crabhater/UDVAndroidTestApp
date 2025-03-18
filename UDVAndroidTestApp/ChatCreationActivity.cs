using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.Services.DI;
using UDVAndroidTestApp.ViewModels;

namespace UDVAndroidTestApp
{
    [Activity(Label = "ChatCreationActivity")]
    public partial class ChatCreationActivity : Activity
    {
        private ChatCreationViewModel _viewModel;
        private EditText _chatTitleEditText;
        private ListView _participantsListView;
        private Button _createChatButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.create_chat);

            var serviceProvider = DependencyInjectionConfig.ServiceProvider;
            _viewModel = serviceProvider.GetService<ChatCreationViewModel>();

            _chatTitleEditText = FindViewById<EditText>(Resource.Id.chatTitleEditText);
            _chatTitleEditText.Text = Intent.GetStringExtra("ChatTitle") ?? string.Empty;

            _participantsListView = FindViewById<ListView>(Resource.Id.participantsListView);
            _createChatButton = FindViewById<Button>(Resource.Id.createChatButton);

            _participantsListView.ChoiceMode = ChoiceMode.Multiple;

            var participantNames = _viewModel.AvailableAccounts.Select(a => a.User.Name).ToList();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, participantNames);
            _participantsListView.Adapter = adapter;

            _createChatButton.Click += (sender, e) =>
            {
                _viewModel.ChatTitle = _chatTitleEditText.Text;

                List<Participant> selectedAccounts = new List<Participant>();
                for (int i = 0; i < _participantsListView.Count; i++)
                {
                    if (_participantsListView.IsItemChecked(i))
                    {
                        selectedAccounts.Add(_viewModel.AvailableAccounts[i]);
                    }
                }

                
                _viewModel.CreateChatCommand.Execute(selectedAccounts);

                Toast.MakeText(this, "Чат создан!", ToastLength.Short).Show();
                Finish(); 
            };
        }

        protected override void OnStop()
        {
            base.OnStop();
            _viewModel.EventsDelete();
        }
    }
}
