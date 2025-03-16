using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDVAndroidTestApp.Core.Interfaces
{
    public interface IChatFolderManager
    {
        Task AddChat(IChat chat);
        Task RemoveChat(IChat chat);
    }
}
