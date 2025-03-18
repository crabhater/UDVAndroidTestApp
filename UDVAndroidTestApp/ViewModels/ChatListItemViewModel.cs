using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.ViewModels
{
    public class ChatListItemViewModel
    {
        public Chat Chat { get; set; }
        public Message LastMessage { get; set; }
        public ChatListItemViewModel(Chat chat, Message lastMessage) 
        {
            Chat = chat;
            LastMessage = lastMessage;
        }

    }
}
