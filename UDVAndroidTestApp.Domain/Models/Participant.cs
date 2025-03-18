using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Data.Interfaces;

namespace UDVAndroidTestApp.Data.Models
{
    public class Participant : IIdentityModel, IUserReference
    {
        public int Id { get; set; }
        public User? user {  get; set; }
        [NotMapped]
        public IAccount User
        {
            get => user;
            set => user = value as User;
        }
    }
}
