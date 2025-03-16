﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.Core.Servies.Base
{
    public abstract class MessageServiceBase : IMessageService
    {
        public abstract Task SendMessage(IMessage message);
    }
}
