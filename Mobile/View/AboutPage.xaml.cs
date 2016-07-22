using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class AboutPage : BasePage
    {
		private int[] randomNumbers = new int[] { 11, 5, 13, 11, 4, 5, 20, 20, 6, 2, 16, 20, 14, 1, 7, 5, 5, 11, 17, 1, 9, 11, 7, 6, 11, 8, 11, 14, 20, 3, 3, 1, 17, 20, 6, 16, 16,
			17, 5, 11, 18, 15, 2, 20, 10, 9, 3, 8, 20, 5 };
		
        public AboutPage()
        {
            InitializeComponent();
			listView.ItemsSource = this.GenerateSource();
			listView.SwipeOffset = Device.OnPlatform<Thickness>(new Thickness(100, 0, 100, 0), 70, 0);
			listView.LayoutDefinition.ItemLength = Device.OnPlatform<double>(60, -1, -1);
        }

		// Button Click
		private async void OnOpenPupup(object sender, EventArgs e)
		{
			var page = new SimulateItemAddPage();
			await Navigation.PushPopupAsync(page);
		}

		private System.Collections.IEnumerable GetSource(int count)
		{
			var items = new List<Item>();
			for (int i = 0; i < count; i++)
			{
				items.Add(new Item { Name = "01/01/2016", Value = "R$10.000,00" });
			}

			return items;
		}

		private System.Collections.IEnumerable GenerateSource()
		{
			var results = new List<Event>();

			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "Falconi" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "Falconi" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "Falconi" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "Falconi" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "Falconi" });

			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "BRF" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "BRF" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "BRF" });
			results.Add(new Event() { Content = "01/01/2016", Value = "R$10.000,00", Day = "BRF" });

			return results;
		}
    }
}
