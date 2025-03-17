using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.App.Repos
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ChatsRepo> _chatsRepo;
        private readonly Lazy<MessagesRepo> _messagesRepo;
        private readonly Lazy<UsersRepo> _usersRepo;

        public IRepository<Chat> ChatsRepo => _chatsRepo.Value; 
        public IRepository<Message> MessageRepo  => _messagesRepo.Value; 

        public IRepository<User> UsersRepo => _usersRepo.Value;

        public RepositoryManager(IAppDataContext context)
        {
            _chatsRepo = new Lazy<ChatsRepo>(new ChatsRepo(context));
            _messagesRepo = new Lazy<MessagesRepo>(new MessagesRepo(context));
            _usersRepo = new Lazy<UsersRepo>(new UsersRepo(context));
        }
    }
}
