using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfPaymentApp.Utils.SharedClass.Message;

namespace WpfPaymentApp.ViewModel.BaseClass
{
    internal abstract class ViewModelBase : INotifyPropertyChanged, IMessenger
    {
        readonly IMessenger messenger = default;

        private ICommand cmdSendMessage = default;

        public ICommand CmdSendMessage { get => cmdSendMessage; set => cmdSendMessage = value; }

        private ViewModelBase() { }

        public ViewModelBase(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected SMessage BuildMessage(string messageText, object messageParameter = null, Action<object> action = null, MessageType messageType = MessageType.Notify)
        {

            return new SMessage { MessageText = messageText, Parameters = messageParameter, MessageType = messageType, MessageAction = action };
        }

        public void SendMessage(SMessage message)
        {
            this.messenger.ReceiveMessage(message);
        }

        public void ReceiveMessage(SMessage message)
        {
            message.MessageAction?.Invoke(message.Parameters);
        }        
    }
}
