using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.Events;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatCreationViewModel : ViewModelBase
    {

        // Коллекция доступных участников (загружается из БД, здесь для примера добавляем вручную)
        public ObservableCollection<Participant> AvailableAccounts { get; set; } = new ObservableCollection<Participant>();

        [ObservableProperty]
        private string chatTitle;

        public ChatCreationViewModel(IRepositoryManager repoMgr, IImpersonateMgr impMgr) : base(repoMgr, impMgr)
        {
            LoadData();
        }

        public override void EventsInit()
        {
            
        }
        public override void EventsDelete()
        {
            
        }

        // Команда для создания чата. В качестве параметра получаем список выбранных участников.
        [RelayCommand]
        public async Task CreateChat(IEnumerable<IUserReference> selectedAccounts)
        {
            if (string.IsNullOrEmpty(ChatTitle))
            {
                return;
            }
            if (selectedAccounts == null || !selectedAccounts.Any())
            {
                return;
            }

            // Используем ChatBuilder для создания нового чата
            var builder = new ChatBuilder()
                .SetTitle(ChatTitle)
                .SetParticipants(selectedAccounts);

            var newChat = builder.Build() as Chat;

            // Сохраняем новый чат в репозитории
            await repoMgr.ChatsRepo.AddAsync(newChat, new CancellationToken());


            WeakReferenceMessenger.Default.Send(new ChatCreatedMessage());
        }

        public override Task LoadData()
        {
            var users = impersonateMgr.PhoneBook.Select(u => new Participant() { User = u });
            AvailableAccounts = new ObservableCollection<Participant>(users);
            return Task.CompletedTask;
        }

    }
}
