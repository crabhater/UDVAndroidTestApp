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
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatCreationViewModel : ViewModelBase
    {
        private readonly IRepository<Chat> _chatRepository;

        // Коллекция доступных участников (загружается из БД, здесь для примера добавляем вручную)
        public ObservableCollection<Account> AvailableAccounts { get; set; } = new ObservableCollection<Account>();

        [ObservableProperty]
        private string chatTitle;

        public ChatCreationViewModel(IRepositoryManager repoMgr) : base(repoMgr)
        {
            _chatRepository = repoMgr.ChatsRepo;

            // Пример загрузки участников — данные могут приходить из БД
            AvailableAccounts.Add(new Account { Id = 1, Name = "Alice", Description = "Участник 1" });
            AvailableAccounts.Add(new Account { Id = 2, Name = "Bob", Description = "Участник 2" });
            AvailableAccounts.Add(new Account { Id = 3, Name = "Charlie", Description = "Участник 3" });
        }

        // Команда для создания чата. В качестве параметра получаем список выбранных участников.
        [RelayCommand]
        public async Task CreateChat(List<Account> selectedAccounts)
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
            await _chatRepository.AddAsync(newChat, new CancellationToken());

            // При необходимости можно сбросить поля или уведомить об успешном создании
        }
    }
}
