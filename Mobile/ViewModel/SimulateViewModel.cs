using System;
using GalaSoft.MvvmLight.Command;
using Mobile.PageLocator;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;


namespace Mobile.ViewModel
{
	public class SimulateViewModel : BaseViewModel
	{
		private bool _isBusy;
		private readonly Service.IMessageService _messageService;

		private Main _locator = new Main();

		public SimulateViewModel()
		{
			//_defaultMessenger = defaultMessenger;
			this._messageService = DependencyService.Get<Service.IMessageService>();
		}

		private String _login = null;
		public String Login
		{
			get
			{
				return _login;
			}
			set
			{
				if (value != _login)
				{
					_login = value;
					RaisePropertyChanged(() => Login);
				}
			}
		}

		private int _close = 0;
		public int Close
		{
			get
			{
				return _close;
			}
			set
			{
				if (value != _close)
				{
					_close = value;
					RaisePropertyChanged(() => Close);
				}
			}
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
							   PopupNavigation.PopAsync();
							   var nav = this.NavigationService;
							   nav.NavigateTo(_locator.AboutPage);
						   }));
			}
		}
	}
}

