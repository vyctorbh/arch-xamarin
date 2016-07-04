using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using Mobile.Model;
using System;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {

        private IAppLoader _appLoader = null;
        private IDefaultMessenger _defaultMessenger = null;
        private bool _isBusy;
        private readonly Service.IMessageService _messageService;

        public LoginViewModel(IAppLoader appLoader, LoginModel loginModel, IDefaultMessenger defaultMessenger): base(defaultMessenger)
        {
            _appLoader = appLoader;
            _defaultMessenger = defaultMessenger;
            this._messageService = DependencyService.Get<Service.IMessageService>();
            IsBusy = false;
            loginModel.Email = "admin@dev.com";
            loginModel.Password = "12345678";
            
            Login = loginModel;
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
                //RaisePropertyChanged("NotIsBusy");
            }
        }

        private LoginModel _login = null;
        public LoginModel Login
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

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                       ?? (_loginCommand = new RelayCommand(
                           async () =>
                           {
                               IsBusy = true;
                               using (var releaser = await _lock.LockAsync())
                               {
                                   await Login.Authenticate();

                                   if (Login.IsAuthenticated)
                                   {
                                       IsBusy = false;
                                       _defaultMessenger.Send(Login.Value);
                                       await _appLoader.LoadStack(StackEnum.Main);
                                   }
                                   else
                                   {
                                       IsBusy = false;
                                       await this._messageService.ShowAsync(Login.Value);
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
