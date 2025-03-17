﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Data.Interfaces;

namespace UDVAndroidTestApp.Data.Models
{
    public class Chat : IChat, IIdentityModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Participant>? participants
        {
            get => Participants?.Cast<Participant>().ToList();
            set => Participants = value?.Cast<IUserReference>().ToList();
        }

        [NotMapped]
        public IEnumerable<IUserReference>? Participants { get; set; }
    }
}
