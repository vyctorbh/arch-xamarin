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
using Mobile.Messenger;

namespace Mobile.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        private bool _isBusy;
        private readonly Service.IMessageService _messageService;
		private IDefaultMessenger _defaultMessenger = null;

        private Main _locator = new Main();

		public MenuViewModel()
        {
            this._messageService = DependencyService.Get<Service.IMessageService>();
            this._defaultMessenger = new DefaultMessenger();
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
								_defaultMessenger.Send(navitem.MainType);
                               var nav = this.NavigationService;
                               nav.NavigateTo(navitem.MainType);
                           }));
            }
        }
    }
}
