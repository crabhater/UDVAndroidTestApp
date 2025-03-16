using Android.App.Usage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatFolderViewModel : ViewModelBase
    {
        public ChatFolderViewModel(IRepositoryManager repoMgr) : base(repoMgr)
        {
            Chats.Add(new Chat { Title = "Тест", Id = 1 } );
        }
        [ObservableProperty]
        private ChatFolder chatFolder;
        public ObservableCollection<Chat> Chats { get; set; } = new ObservableCollection<Chat>();

        [RelayCommand]
        public async Task AddChat()
        {

        }
    }
}
