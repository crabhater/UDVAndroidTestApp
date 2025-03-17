using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Core.Interfaces
{
    public interface IMessage
    {
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
        public IUserReference Sender { get; set; }
        public IChat Chat { get; set; }
    }
}
