using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mobile.View
{
    public partial class MainPage : BasePage
    {
		private int[] randomNumbers = new int[] { 11, 5, 13, 11, 4, 5, 20, 20, 6, 2, 16, 20, 14, 1, 7, 5, 5, 11, 17, 1, 9, 11, 7, 6, 11, 8, 11, 14, 20, 3, 3, 1, 17, 20, 6, 16, 16,
			17, 5, 11, 18, 15, 2, 20, 10, 9, 3, 8, 20, 5 };

		public MainPage()
		{
			InitializeComponent();
			listView.ItemsSource = this.GetSource(50);
			listView.SwipeOffset = Device.OnPlatform<Thickness>(new Thickness(100, 0, 100, 0), 70, 0);
			listView.LayoutDefinition.ItemLength = Device.OnPlatform<double>(60, -1, -1);
		}

		private System.Collections.IEnumerable GetSource(int count)
		{
			var items = new List<Item>();
			for (int i = 0; i < count; i++)
			{
				items.Add(new Item { Name = "BRF", Value = "06/07/2016" });
			}

			return items;
		}

		private void IncreaseButtonClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			var item = button.BindingContext as Item;
			//item.Value++;
			listView.EndItemSwipe();
		}

		private void DecreaseButtonClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			var item = button.BindingContext as Item;
			//if (item.Value > 0)
			//{
			//	item.Value--;
			//}

			listView.EndItemSwipe();
		}
    }



	public class Item : INotifyPropertyChanged
	{
		private string name;
		private int age;
		private string value;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Value
		{
			get
			{
				return this.value;
			}
			set
			{
				if (this.value != value)
				{
					this.value = value;
					this.RaisePropertyChanged();
				}
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.name != value)
				{
					this.name = value;
					this.RaisePropertyChanged();
				}
			}
		}

		public int Age
		{
			get
			{
				return this.age;
			}
			set
			{
				if (this.age != value)
				{
					this.age = value;
					this.RaisePropertyChanged();
				}
			}
		}

		private void RaisePropertyChanged([CallerMemberName]
										  string propertyName = null)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
			{
				lock (handler)
				{
					handler(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
	}
}
