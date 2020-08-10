using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPaymentApp.Utils.SharedClass.Message
{
    public interface IMessenger
    {
        void SendMessage(SMessage message);
        void ReceiveMessage(SMessage message);
    }
}
