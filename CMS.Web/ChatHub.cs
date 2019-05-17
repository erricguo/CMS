using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace CMS.Web
{
    public class ChatHub : Hub
    {
        public void send(string Name,string Message)
        {
            Clients.All.addMessageToPage(Name, Message, DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}