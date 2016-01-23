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
    public class MainViewModel : BaseViewModel
    {
        private IDefaultMessenger _defaultMessenger = null;
        private IAppLoader _appLoader = null;
        public string numberpage { get; set; }
        public string skippage { get; set; }
        public int qtdrows { get; set; }

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
                if (value != null && value.Count > 0)
                {
                    this.qtdrows = value[0].qtdrows;
                }
                RaisePropertyChanged(() => Items);
            }
        }

        private List<string> _ButtonItems;
        public List<string> ButtonItems
        {
            get
            {
                return _ButtonItems;
            }
            set
            {
                _ButtonItems = value;
                RaisePropertyChanged(() => ButtonItems);
            }
        }

        private Command loadModelsCommand;
        public Command LoadModelsCommand
        {
            get
            {
                return loadModelsCommand ?? (loadModelsCommand = new Command(ExecuteLoadModelsCommand));
            }
        }

        protected virtual async void ExecuteLoadModelsCommand()
        {
            await MainModel.List(null, null, null, this.numberpage, this.skippage);
            this.Items = MainModel.Items;
        }

        public MainViewModel(IAppLoader appLoader, MainModel mainModel, IDefaultMessenger defaultMessenger) : base(defaultMessenger)
        {
            _appLoader = appLoader;
            MainModel = mainModel;
            this.IsLoading = false;
            MainModel.IsLoading = false;
            _defaultMessenger = defaultMessenger;
            this.numberpage = "20";
            this.skippage = "0";
            LoadModelsCommand.Execute(null);

            /*ButtonItems = new ObservableCollection<string>
            {
                "Xamarin",
                "Xamarin.Forms"
            };*/
        }


        public override void Subscribe()
        {
            _defaultMessenger.RegisterNotification(this, ReceiveNotification);
        }

        private void ReceiveNotification(string message)
        {
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

        private string _search = "";
        public string SearchItem
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                RaisePropertyChanged(() => SearchItem);
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }

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

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return _searchCommand
                       ?? (_searchCommand = new RelayCommand(
                           async () =>
                           {
                               IsBusy = true;
                               this.skippage = "0";
                               using (var releaser = await _lock.LockAsync())
                               {
                                   await MainModel.List(this.SearchItem, null, null, this.numberpage, this.skippage);
                                   this.Items = MainModel.Items;
                                   IsLoading = false;
                                   IsBusy = false;
                               }
                           }));
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
                                   if (Convert.ToInt32(this.skippage) <= this.qtdrows && IsLoading)
                                   {
                                       this.skippage = (Convert.ToInt32(this.skippage) + Convert.ToInt32(this.numberpage)).ToString();
                                       await MainModel.List(this.SearchItem, null, null, this.numberpage, this.skippage);
                                       foreach (var item in MainModel.Items)
                                       {
                                           this.Items.Add(item);
                                       }
                                       IsLoading = false;
                                       IsBusy = false;
                                   }
                               }
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
