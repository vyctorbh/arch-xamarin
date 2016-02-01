using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Model;
using Xamarin.Forms;
using System.Windows.Input;

namespace Mobile.Helper
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<Mobile.Model.MenuItem> data = new MenuListData();

            ItemsSource = data;
            SelectedItem = 
            VerticalOptions = LayoutOptions.FillAndExpand;
            //BackgroundColor = Color.Transparent;

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

            ItemTemplate = cell;
        }

        public static Mobile.Model.MenuItem menuSelect;

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<MenuListView, object>(i => i.CommandParameter, default(object), BindingMode.OneWay);

        public object CommandParameter
        {
            get
            {
                return this.GetValue(CommandParameterProperty);
            }
            set
            {
                this.SetValue(CommandParameterProperty, value);
            }
        }

        public static readonly BindableProperty ListItemTappedCommandProperty = BindableProperty.CreateAttached<MenuListView, ICommand>(
            staticgetter: o => (ICommand)o.GetValue(ListItemTappedCommandProperty),
            defaultValue: default(ICommand),
            propertyChanged: (o, old, @new) =>
            {
                var lv = o as ListView;
                if (lv == null) return;

                lv.ItemTapped -= ListView_ItemTapped;
                lv.ItemTapped += ListView_ItemTapped;
            });

        private static void ListView_ItemTapped(object sender, object item)
        {
            var lv = sender as ListView;

            //if(item != null)
            //{
            //    menuSelect = (Mobile.Model.MenuItem)((ItemTappedEventArgs)item).Item;
            //}

            var command = (ICommand)lv?.GetValue(ListItemTappedCommandProperty);
            if (command == null) return;

            if (command.CanExecute(item))
                command.Execute(item);
        }
    }
}
