using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.App.Interfaces
{
    public interface IRepositoryManager
    {
        public IRepository<Chat> ChatsRepo { get; }
        public IRepository<Message> MessageRepo { get; }
    }
}
