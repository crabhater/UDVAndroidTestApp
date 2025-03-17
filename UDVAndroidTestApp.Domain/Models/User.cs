using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Data.Interfaces;

namespace UDVAndroidTestApp.Core.Models
{
    public class User : IAccount, IIdentityModel
    {
        public int Id { get; set; }
        public string? Name { get ; set ; }
        public string? Description { get ; set ; }
    }
}
