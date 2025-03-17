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
    public class ChatBuilder : ModelBuilderBase<IChat>
    {
        public ChatBuilder()
        {
            model = new Chat();
            model.Participants = new List<IUserReference>();
        }
        public ChatBuilder SetTitle(string title)
        {
            model.Title = title;
            return this;
        }
        public ChatBuilder SetParticipants(IEnumerable<IUserReference> accounts)
        {
            model.Participants = accounts;
            return this;
        }
        public ChatBuilder AddParticipiant(IAccount account)
        {
            (model.Participants as List<IAccount>).Add(account);
            return this;
        }
        public override IChat Build()
        {
            return model;
        }
    }
}
