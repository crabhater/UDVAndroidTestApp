using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.Core.Servies.Base
{
    public abstract class ChatFolderManagetBase : IChatFolderManager
    {
        protected IChatFolder folder;
        public ChatFolderManagetBase(IChatFolder folder)
        {
            this.folder = folder;
        }
        public abstract Task AddChat(IChat chat);

        public abstract Task RemoveChat(IChat chat);
    }
}
