using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfPaymentApp.Utils.SharedClass.Message;

namespace WpfPaymentApp.Utils.SharedClass.Helpers
{
    internal static class ContextRegister
    {
        public static void Register<T>(this UserControl owner, object[] parameters = null)
        {
            owner.DataContext = Activator.CreateInstance(typeof(T), AddDataContext((IMessenger)owner, parameters));
        }

        public static void Register<T>(this Window owner, object[] parameters = null)
        {
            owner.DataContext = Activator.CreateInstance(typeof(T), AddDataContext((IMessenger)owner, parameters));
        }

        private static object[] AddDataContext(IMessenger owner, object[] parameters)
        {
            IList<object> vParams = (parameters != default) ? new List<object>(parameters) : new List<object>();

            vParams.Insert(0, owner);


            return vParams.ToArray();
        }


        public static void ContextShowMessage(this UserControl userControl, SMessage message)
        {
            ShowMessage(message);
        }

        public static void ContextShowMessage(this Window userControl, SMessage message)
        {
            ShowMessage(message);
        }

        public static void ContextMessage(this UserControl userControl, SMessage message)
        {
            SendMessage(((IMessenger)userControl.DataContext), message);
        }

        public static void ContextSendMessage(this Window userControl, SMessage message)
        {
            SendMessage(((IMessenger)userControl.DataContext), message);
        }

        private static void ShowMessage(SMessage message)
        {
            switch (message.MessageType)
            {
                case MessageType.Notify:
                    MessageBox.Show(message.MessageText, "", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageType.Error:
                    MessageBox.Show(message.MessageText, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case MessageType.YesNo:
                    MessageBox.Show(message.MessageText, "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    MessageBox.Show(message.MessageText);
                    break;
                case MessageType.StartProcess:
                    break;
                case MessageType.EndProcess:
                    break;
                default:
                    break;
            }
        }
        private static void SendMessage(IMessenger messenger, SMessage message)
        {
            messenger.ReceiveMessage(message);
        }

        public static void UnRegister<T>(this UserControl userControl)
        {
            userControl.DataContext = null;
        }

        public static void UnRegister<T>(this Window window)
        {
            window.DataContext = null;
        }


    }
}
