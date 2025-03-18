using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.Core.Models
{
    public class ImpersonateMgr : IImpersonateMgr
    {
        public User CurrentUser { get; set; }
        public IEnumerable<User> PhoneBook { get; set; }

    }
}
