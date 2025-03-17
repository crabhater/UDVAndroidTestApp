using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.Events
{
    public class ChatMessageCreatedMessage
    {
        public IMessage Message { get; private set; }
        public ChatMessageCreatedMessage(IMessage message) 
        {
            Message = message;
        }
    }
}
