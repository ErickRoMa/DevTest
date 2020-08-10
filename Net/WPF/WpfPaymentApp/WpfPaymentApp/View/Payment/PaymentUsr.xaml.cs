using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPaymentApp.Utils.SharedClass.Helpers;
using WpfPaymentApp.Utils.SharedClass.Message;
using WpfPaymentApp.ViewModel.Payment;

namespace WpfPaymentApp.View.Payment
{
    /// <summary>
    /// Interaction logic for PaymentUsr.xaml
    /// </summary>
    public partial class PaymentUsr : UserControl, IMessenger
    {
        public PaymentUsr()
        {
            InitializeComponent();
            this.Register<PaymentVM>();
        }

        public void ReceiveMessage(SMessage message)
        {
            this.ContextShowMessage(message);
            this.SendMessage(message);
        }

        public void SendMessage(SMessage message)
        {
            this.ContextMessage(message);
        }
    }
}
