using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Servies.Base;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Core.Servies.FluentBuilder
{
    public class MessageBuilder : ModelBuilderBase<IMessage>
    {
        public MessageBuilder()
        {
            model = new Message();
            model.Date = DateTime.Now;
        }
        public MessageBuilder SetChat(IChat chat)
        {
            model.Chat = chat;
            return this;
        }
        public MessageBuilder SetSender(IUserReference account)
        {
            model.Sender = account;
            return this;
        }
        public MessageBuilder SetContent(string content)
        {
            model.Content = content;
            return this;
        }
        public override IMessage Build()
        {
            return model;
        }
    }
}
