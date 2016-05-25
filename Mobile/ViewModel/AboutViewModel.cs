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
        private IAppLoader _appLoader = null;
        public string numberpage { get; set; }
        public string skippage { get; set; }
        public int qtdrows { get; set; }

        private MainModel _mainModel = null;
        public MainModel MainModel
        {
            get
            {
                return _mainModel;
            }
            set
            {
                if (value != _mainModel)
                {
                    _mainModel = value;
                    RaisePropertyChanged(() => MainModel);
                }
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        private ObservableCollection<MainModel> _Items;
        public ObservableCollection<MainModel> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        public AboutViewModel(IAppLoader appLoader, MainModel mainModel, IDefaultMessenger defaultMessenger) : base(defaultMessenger)
        {
            _appLoader = appLoader;
            MainModel = mainModel;
            this.IsLoading = false;
            MainModel.IsLoading = false;
            _defaultMessenger = defaultMessenger;
            this.numberpage = "20";
            this.skippage = "0";
        }

        public override void Subscribe()
        {
            _defaultMessenger.RegisterNotification(this, ReceiveNotification);
        }

        private void ReceiveNotification(string message)
        {
			PageLocator.Main _main = new Mobile.PageLocator.Main ();
			if (message.Contains ("Basic"))
				Message = message;
			else if (message.Contains (_main.AboutPage))
				this.LoadMoreCommand.Execute (null);
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
                //LoadMoreCommand.Execute(null);
                RaisePropertyChanged(() => Message);
            }
        }

        private RelayCommand _loadmoreCommand;
        public RelayCommand LoadMoreCommand
        {
            get
            {
                return _loadmoreCommand
                       ?? (_loadmoreCommand = new RelayCommand(
                           async () =>
                           {
                               IsLoading = true;
                               IsBusy = true;
                               using (var releaser = await _lock.LockAsync())
                               {
                                   //   this.skippage = (Convert.ToInt32(this.skippage) + Convert.ToInt32(this.numberpage)).ToString();
                                   await MainModel.List("Cotacao", null, null, this.numberpage, this.skippage, this.Message);
                                   this.Items = new ObservableCollection<MainModel>();
                                   foreach (var item in MainModel.Items)
                                   {
                                       this.Items.Add(item);
                                   }
                                   IsLoading = false;
                                   IsBusy = false;
                               }
                           }));
            }
        }


        private Command _detailsCommand;
        public Command DetailsCommand
        {
            get
            {
                return _detailsCommand
                       ?? (_detailsCommand = new Command<ItemTappedEventArgs>(
                           async (item) =>
                           {
                               var navitem = (MainModel)item.Item;

                               DetailsModel details = new DetailsModel();
                               details.ID = navitem.id;
                               MainModel.ItemNews = navitem;

                               _defaultMessenger.Send(navitem.id.ToString());
                               Mobile.PageLocator.Main _locator = new PageLocator.Main();
                               var nav = this.NavigationService;
                               nav.NavigateTo(_locator.DetailsPage);
                           }));
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();

            _defaultMessenger.Unregister(this);
        }
    }
}
