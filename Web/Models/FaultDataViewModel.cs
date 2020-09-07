using BizTalk.Monitor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models
{
    public class FaultDataViewModel
    {

        public Fault  Fault { get; set; }

        public Message Message { get; set; }
    }
}
