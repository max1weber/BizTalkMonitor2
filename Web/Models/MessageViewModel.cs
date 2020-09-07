using BizTalk.Monitor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models
{
    public class MessageViewModel: Message
    {

        public string Content{ get; set; }

    }
}
