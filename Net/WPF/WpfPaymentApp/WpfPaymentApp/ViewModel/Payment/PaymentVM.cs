using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPaymentApp.Utils.SharedClass.Message;
using WpfPaymentApp.ViewModel.BaseClass;
using WpfPaymentApp.ViewModel.SharedClass;

namespace WpfPaymentApp.ViewModel.Payment
{
    internal class PaymentVM : ViewModelBase
    {
        public PaymentVM(IMessenger context) : base(context)
        {
            CmdSendMessage = new RelayCommand((object sender) =>
            {
                this.SendMessage(
                    this.BuildMessage("Mensaje de Prueba", action: (param) => { ReadResponse(param); }));
            });
        }


        private void ReadResponse(object message)
        {
            if (message != default) {
                return;
            }
        }
    }
}
