using Mobile.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using Mobile.View;
using System.Collections.ObjectModel;

namespace Mobile.Helper
{
    public class InfiniteListView : ListView
    {
        private ObservableCollection<AccordionItem> _items;
        public ICollection<AccordionItem> Items
        {
            get { return _items; }
        }

        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create<InfiniteListView, ICommand>(bp => bp.LoadMoreCommand, default(ICommand));
        //public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create<InfiniteListView, bool>(bp => bp.IsLoading, default(bool));

        public static BindableProperty IsLoadingProperty =
        BindableProperty.Create<InfiniteListView, bool>(ctrl => ctrl.IsLoading,
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (InfiniteListView)bindable;
            ctrl.IsLoading = newValue;
        });

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case "IsLoading":
                    //IsLoading = false;
                    var teste = "";
                    break;
            }
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public InfiniteListView()
        {
            this.HasUnevenRows = true;
            ItemAppearing += InfiniteListView_ItemAppearing;
            _items = new ObservableCollection<AccordionItem>();
            ItemsSource = _items;
        }

        void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            /*var items = ItemsSource as IList;

            if (this.IsLoading)
                return;

            if (items != null && !(((MainModel)e.Item).id == ((MainModel)items[items.Count - 1]).id))
                return;

            IsLoading = true;

            if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                LoadMoreCommand.Execute(null);*/
        }

        public void Toggle(AccordionCell selectedItem)
        {
            foreach (var item in _items)
            {
                if (item.Cell != null)
                {
                    item.IsSelected = false;
                    //item.Cell.hide();
                }
            }
            //selectedItem.Height = 100;
            selectedItem.IsSelected = true;
        }
    }

    public class AccordionItem : BindableObject
    {
        public string Title { get; set; }
        public string Content { get; set; }
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public AccordionCell Cell { get; set; }
    }
}
