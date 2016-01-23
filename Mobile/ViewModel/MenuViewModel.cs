using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Mobile.Model;
using Mobile.PageLocator;
using Mobile.View;
using System;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        private bool _isBusy;
        private readonly Service.IMessageService _messageService;

        private Main _locator = new Main();

        public MenuViewModel()
        {
            //_defaultMessenger = defaultMessenger;
            this._messageService = DependencyService.Get<Service.IMessageService>();
        }

        private RelayCommand _aboutCommand;
        public RelayCommand AboutCommand
        {
            get
            {
                return _aboutCommand
                       ?? (_aboutCommand = new RelayCommand(
                           async () =>
                           {
                               var nav = this.NavigationService;
                               nav.NavigateTo(_locator.AboutPage);
                           }));
            }
        }
    }
}
