using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDVAndroidTestApp.Core.Interfaces
{
    public interface IChatFolder
    {
        public IEnumerable<IChat> Chats { get; set; }
    }
}
