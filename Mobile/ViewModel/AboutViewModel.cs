using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using Mobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class AboutViewModel: BaseViewModel
    {
        private IDefaultMessenger _defaultMessenger = null;

        public AboutViewModel(IAppLoader appLoader, MainModel mainModel, IDefaultMessenger defaultMessenger) : base(defaultMessenger)
        {
            _defaultMessenger = defaultMessenger;
        }

        public override void Subscribe()
        {
            _defaultMessenger.RegisterNotification(this, ReceiveNotification);
        }

        private void ReceiveNotification(string message)
        {
            if (message.Contains("Basic"))
                Message = message;
        }

        private string _message = "Default Message";
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }
    }
}
