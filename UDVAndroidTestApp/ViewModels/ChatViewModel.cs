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

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatViewModel : ViewModelBase
    {
        public ChatViewModel(IRepositoryManager repoMgr, IImpersonateMgr impMgr) : base(repoMgr, impMgr)
        {
            EventsInit();
        }

        
        [ObservableProperty]
        private string inputMessage;
        
        [ObservableProperty]
        private ObservableCollection<Message> messages = new ObservableCollection<Message>();

        [ObservableProperty]
        private IChat chat;
        public int ChatId { get; set; }

        public override void EventsInit()
        {
            WeakReferenceMessenger.Default.Register<ChatMessageCreatedMessage>(this, async (r, message) =>
            {
                await LoadData();
            });
        }
        public override void EventsDelete()
        {
            WeakReferenceMessenger.Default.Unregister<ChatMessageCreatedMessage>(this);
        }

        public override async Task LoadData()
        {
            Chat = await repoMgr.ChatsRepo.GetInstance().SingleAsync(c => c.Id == ChatId);
            var messagesList = await repoMgr.MessageRepo.GetInstance().Where(m => m.chat.Id == ChatId).ToListAsync();
            Messages.Clear();
            foreach (var message in messagesList)
            {
                messages.Add(message);
            }
        }

        public async Task CreateMessage(string content)
        {
            var messageBuilder = new MessageBuilder();

            var userRef = new Participant() { User = impersonateMgr.CurrentUser };
            var message = messageBuilder.SetChat(Chat)
                                        .SetContent(content)
                                        .SetSender(userRef)
                                        .Build() as Message;

            await repoMgr.MessageRepo.AddAsync(message, new CancellationToken());
            WeakReferenceMessenger.Default.Send(new ChatMessageCreatedMessage());

            foreach (var participant in Chat.Participants)
            {
                var messageSamples = new List<string>()
                {
                    "Что он вообще несет?",
                    "Как покинуть группу??",
                    "Он и здесь меня нашел(((", 
                    "Я звоню в полицию!",
                    "Я в шоке..."
                };
                var randMessage = new Random().Next(messageSamples.Count);
                messageBuilder = new MessageBuilder();
                var botMessage = messageBuilder.SetChat(Chat)
                                               .SetContent(messageSamples[randMessage])
                                               .SetSender(participant)
                                               .Build() as Message;

                await Task.Delay(500);
                await repoMgr.MessageRepo.AddAsync(botMessage, new CancellationToken());
                WeakReferenceMessenger.Default.Send(new ChatMessageCreatedMessage());
            }


        }

    }
}
