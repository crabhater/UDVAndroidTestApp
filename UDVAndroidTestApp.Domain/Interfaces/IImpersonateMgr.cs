using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Models;

namespace UDVAndroidTestApp.Core.Interfaces
{
    public interface IImpersonateMgr
    {
        public User CurrentUser { get; set; }
        public IEnumerable<User> PhoneBook { get; set; }
    }
}
