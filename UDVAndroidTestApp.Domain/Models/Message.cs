using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Data.Interfaces;

namespace UDVAndroidTestApp.Data.Models
{
    public class Message : IMessage, IIdentityModel
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
        public Account? sender
        {
            get => (Account)Sender;
            set => Sender = value;
        }
        public Chat chat 
        {
            get => (Chat)Chat;
            set => Chat = value;
        }
        [NotMapped]
        public IAccount Sender { get; set; }
        [NotMapped]
        public IChat Chat { get ; set ; }
    }
}
