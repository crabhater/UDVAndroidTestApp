using Android.App.Usage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.Events;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatFolderViewModel : ViewModelBase
    {
        public ChatFolderViewModel(IRepositoryManager repoMgr, IImpersonateMgr impMgr) : base(repoMgr, impMgr)
        {
            EventsInit();
        }
        [ObservableProperty]
        public ObservableCollection<ChatListItemViewModel> chats = new ObservableCollection<ChatListItemViewModel>();

        public override void EventsInit()
        {
            // Подписка 
            WeakReferenceMessenger.Default.Register<ChatCreatedMessage>(this, async (r, message) =>
            {
                await LoadData();
            });
            WeakReferenceMessenger.Default.Send(new ChatCreatedMessage());
        }

        public override void EventsDelete()
        {
            WeakReferenceMessenger.Default.Unregister<ChatCreatedMessage>(this);
        }
        public override async Task LoadData()
        {
            //Тащим из бд или предоставляем пустой список
            var chatList = await repoMgr.ChatsRepo.GetInstance().ToListAsync();
            Chats.Clear();
            foreach (var chat in chatList)
            {
                var lastMessage = await repoMgr.MessageRepo.GetInstance()
                                                       .Where(m => m.chat.Id == chat.Id)
                                                       .OrderByDescending(m => m.Id)
                                                       .FirstOrDefaultAsync();
                Chats.Add(new ChatListItemViewModel(chat, lastMessage));
            }
        }

    }
}
