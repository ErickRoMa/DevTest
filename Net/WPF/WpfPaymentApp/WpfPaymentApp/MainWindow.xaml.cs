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
using WpfPaymentApp.ViewModel.Main;

namespace WpfPaymentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMessenger
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Register<MainWindowVM>();
        }

        public void ReceiveMessage(SMessage message)
        {
            this.ContextShowMessage(message);
            this.SendMessage(message);
        }

        public void SendMessage(SMessage message)
        {
            this.ContextSendMessage(message);
        }
    }
}
