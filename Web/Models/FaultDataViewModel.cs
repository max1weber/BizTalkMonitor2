using BizTalk.Monitor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models
{
    public class FaultDataViewModel
    {

        public FaultDataViewModel()
        {
            Message = new MessageViewModel();
        }

        public Fault  Fault { get; set; }

        public MessageViewModel Message { get; set; }

        public IQueryable<ContextProperty> Properties { get; set; }


        public void AssignMessage(Message source)
        {
            Message.ActivityId =  source.ActivityId ;
            Message.ContentType = source.ContentType;
            Message.InterchangeId = source.InterchangeId;
            Message.MessageId = source.MessageId;
            Message.MessageName = source.MessageName;
            Message.NativeMessageId = source.NativeMessageId;
            Message.ResubmitAttempted = source.ResubmitAttempted;
            Message.ResubmitSuccessful = source.ResubmitSuccessful;
            Message.RoutingUrl = source.RoutingUrl;
            Message.InsertedDate = source.InsertedDate;
            Message.FaultId = source.FaultId;
            

        }

        public void AssignMessageContent(MessageData source)
        {
            Message.Content =source.MessageData1 ;


        }
    }
}
