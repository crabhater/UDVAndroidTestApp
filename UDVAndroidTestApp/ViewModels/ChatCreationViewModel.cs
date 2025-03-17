using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.App.Repos;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.Services.Personality;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatCreationViewModel : ViewModelBase
    {

        // Коллекция доступных участников (загружается из БД, здесь для примера добавляем вручную)
        public ObservableCollection<Participant> AvailableAccounts { get; set; } = new ObservableCollection<Participant>();

        [ObservableProperty]
        private string chatTitle;

        public ChatCreationViewModel(IRepositoryManager repoMgr) : base(repoMgr)
        {
            Init();
        }

        public override void Init()
        {
            var users = ImpersonateMgr.PhoneBook.Select(u => new Participant() { User = u });
            AvailableAccounts = new ObservableCollection<Participant>(users);
        }

        // Команда для создания чата. В качестве параметра получаем список выбранных участников.
        [RelayCommand]
        public async Task CreateChat(IEnumerable<IUserReference> selectedAccounts)
        {
            if (string.IsNullOrEmpty(ChatTitle))
            {
                // Здесь можно уведомить пользователя, что необходимо ввести название
                return;
            }
            if (selectedAccounts == null || !selectedAccounts.Any())
            {
                // Здесь можно уведомить пользователя, что нужно выбрать хотя бы одного участника
                return;
            }

            // Используем ChatBuilder для создания нового чата
            var builder = new ChatBuilder()
                .SetTitle(ChatTitle)
                .SetParticipants(selectedAccounts);

            var newChat = builder.Build() as Chat;

            // Сохраняем новый чат в репозитории
            await repoMgr.ChatsRepo.AddAsync(newChat, new CancellationToken());

            // При необходимости можно сбросить поля или уведомить об успешном создании
        }
    }
}
