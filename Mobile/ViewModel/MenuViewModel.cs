using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Mobile.Model;
using Mobile.PageLocator;
using Mobile.View;
using Mobile.ViewModel;
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

        private Command _aboutCommand;
        public Command AboutCommand
        {
            get
            {
                return _aboutCommand
                       ?? (_aboutCommand = new Command<ItemTappedEventArgs>(
                           async (item) =>
                           {
                               var navitem = (Mobile.Model.MenuItem)item.Item;
                               var nav = this.NavigationService;
                               nav.NavigateTo(navitem.MainType);
                           }));
            }
        }
    }
}
