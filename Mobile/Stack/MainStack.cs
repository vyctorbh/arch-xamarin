using Definition.Interfaces;
using Mobile.PageLocator;
using Mobile.View;
using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Stack
{
    public class MainStack : BaseStack, IStack
    {

        private Main _locator = new Main();
        private AppLoader _appLoader = null;

        public MainStack(AppLoader appLoader)
        {
            _appLoader = appLoader;
            var color = Mobile.Helper.Color.Blue.ToFormsColor();
            NavigationPage = new NavigationPage()
            {
                BarBackgroundColor = color,
                BarTextColor = Mobile.Helper.Color.White.ToFormsColor(),
                Title = "Descubra"
            };

            MainPage = new MasterDetailPage()
            {
                BackgroundColor = Color.Transparent,
                Master = BuildMenuPage(),
                Detail = NavigationPage,
                MasterBehavior = MasterBehavior.Popover
            };
        }

        private Page BuildMenuPage()
        {
            return new MenuPage()
            {             
                Title = "Menu",
                Icon = "Menu.png",  //TODO: add in default icon 
                BindingContext = new MenuViewModel(),
                BackgroundColor = Color.FromHex("5ec8de")
            };
        }

        protected override void MapPages()
        {
            _navigationService.Map(_locator.MainPage, typeof(MainPage));
            _navigationService.Map(_locator.AboutPage, typeof(AboutPage));
        }

        protected override void MapViewModels()
        {
            _pageService.Map(typeof(MainPage), typeof(MainViewModel));
            _pageService.Map(typeof(AboutPage), typeof(AboutViewModel));
        }

        protected override string NavigationStartPageKey
        {
            get
            {
                return _locator.MainPage;
            }
        }
    }
}
