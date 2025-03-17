using Android.Service.VR;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.Events;
using UDVAndroidTestApp.Services.Personality;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatViewModel : ViewModelBase
    {
        public ChatViewModel(IRepositoryManager repoMgr) : base(repoMgr) 
        {
        }

        
        [ObservableProperty]
        private string inputMessage;
        
        [ObservableProperty]
        private ObservableCollection<Message> messages;

        [ObservableProperty]
        private IChat chat;
        public int ChatId { get; set; }

        public override void Init()
        {
            WeakReferenceMessenger.Default.Register<ChatMessageCreatedMessage>(this, async (r, message) =>
            {
                await LoadMessages();
            });
            WeakReferenceMessenger.Default.Send(new ChatMessageCreatedMessage(new Message()));

        }

        public async Task LoadMessages()
        {
            chat = repoMgr.ChatsRepo.GetInstance().Include(c => c.participants).Single(c => c.Id == ChatId);
            var messagesList = await repoMgr.MessageRepo.GetInstance().Where(m => m.chat == chat).ToListAsync();
            messages = new ObservableCollection<Message>(messagesList);
        }

        public async Task CreateMessage(string content)
        {
            var messageBuilder = new MessageBuilder();

            var userRef = new Participant() { User = ImpersonateMgr.CurrentUser };
            var message = messageBuilder.SetChat(Chat)
                                        .SetContent(content)
                                        .SetSender(userRef)
                                        .Build() as Message;

            await repoMgr.MessageRepo.AddAsync(message, new CancellationToken());
            WeakReferenceMessenger.Default.Send(new ChatMessageCreatedMessage(message));                

            foreach (var participant in chat.Participants)
            {
                var botMessage = messageBuilder.SetChat(Chat)
                                               .SetContent("Что он вообще несет?")
                                               .SetSender(participant)
                                               .Build() as Message;

                await repoMgr.MessageRepo.AddAsync(botMessage, new CancellationToken());
                WeakReferenceMessenger.Default.Send(new ChatMessageCreatedMessage(message));

            }

        }
    }
}
