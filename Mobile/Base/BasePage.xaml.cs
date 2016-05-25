using Definition.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Mobile.View
{
    public partial class BasePage : ContentPage, ICleanupPage
    {

        public Guid PageInstanceId { get; set; }

        public static readonly BindableProperty OnAppearingCommandProperty = BindableProperty.CreateAttached<BasePage, ICommand>(
            staticgetter: o => (ICommand)o.GetValue(OnAppearingCommandProperty),
            defaultValue: default(ICommand));

        public BasePage()
        {
            InitializeComponent();
            PageInstanceId = Guid.NewGuid();
        }

        protected override void OnAppearing()
        {
            var lv = this;
            var command = (ICommand)lv.GetValue(OnAppearingCommandProperty);
            if (command == null) return;

            if (command.CanExecute(null))
                command.Execute(null);
            base.OnAppearing();
        }

        public virtual void Cleanup() { }
    }
}
