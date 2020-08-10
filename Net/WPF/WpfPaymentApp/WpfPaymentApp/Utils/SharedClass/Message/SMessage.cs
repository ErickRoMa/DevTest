using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPaymentApp.Utils.SharedClass.Message
{
    public class SMessage
    {
        public IMessenger MessageOwner { get; set; }
        public MessageType MessageType { get; set; }
        public string MessageText { get; set; }

        public object Parameters { get; set; }
        public Action<object> MessageAction { get; set; }
    }

    public enum MessageType
    {        
        Notify,
        Error,
        YesNo,
        StartProcess,
        EndProcess
    }
}
