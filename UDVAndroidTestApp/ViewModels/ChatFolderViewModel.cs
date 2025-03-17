using Android.App.Usage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
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
            //Тащим из бд или предоставляем пустой список
            var chatList = repoMgr.ChatsRepo.GetInstance().ToList();
            Chats = new ObservableCollection<Chat>(chatList ?? new List<Chat>());
        }
        public ObservableCollection<Chat> Chats { get; set; } 

    }
}
