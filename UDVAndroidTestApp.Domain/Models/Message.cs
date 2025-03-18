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
        public Participant? sender { get; set; }
        public Chat? chat { get; set; }
        [NotMapped]
        public IUserReference Sender
        {
            get => sender;
            set => sender = value as Participant;
        }
        [NotMapped]
        public IChat Chat
        {
            get => chat;
            set => chat = value as Chat;
        }
    }
}
