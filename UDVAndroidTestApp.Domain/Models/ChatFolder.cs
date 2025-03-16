using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Core.Models
{
    public class ChatFolder : IChatFolder
    {
        public List<Chat> chats
        {
            get => Chats.Cast<Chat>().ToList();
            set => Chats = value.Cast<IChat>().ToList();
        }

        [NotMapped]
        public IEnumerable<IChat> Chats { get; set; }
    }
}
