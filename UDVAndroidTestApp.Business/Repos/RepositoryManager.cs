using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.App.Repos
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ChatsRepo> _chatsRepo;
        private readonly Lazy<MessagesRepo> _messagesRepo;

        public IRepository<Chat> ChatsRepo { get => _chatsRepo.Value; }
        public IRepository<Message> MessageRepo { get => _messagesRepo.Value; }

        public RepositoryManager(IAppDataContext context)
        {
            _chatsRepo = new Lazy<ChatsRepo>(new ChatsRepo(context));
            _messagesRepo = new Lazy<MessagesRepo>(new MessagesRepo(context));
        }
    }
}
