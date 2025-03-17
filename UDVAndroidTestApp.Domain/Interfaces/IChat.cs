using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Core.Interfaces
{
    public interface IChat
    {
        public string Title { get; set; }
        public IEnumerable<IAccount>? Participants { get; set; }
    }
}
