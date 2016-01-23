using Mobile.Helper;
using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();

            var buttonGroupTagCloudItems = new List<string>
            {
                "Lista",
                "Mapa"
            };
            listViews.Items.Add(new AccordionItem { Title = "Item #1", Content = "Body content #1", IsSelected = true });
            listViews.Items.Add(new AccordionItem { Title = "Item #2", Content = "Body content #2" });
            listViews.Items.Add(new AccordionItem { Title = "Item #3", Content = "Body content #3" });
            //bgButton.Items = buttonGroupTagCloudItems;
            //bgButton.ViewBackgroundColor = Color.FromHex("5ec8de");
            //bgButton.BackgroundColor = Color.FromHex("c8c8cd");
            //bgButton.Padding = new Thickness(5);
        }
    }
}
