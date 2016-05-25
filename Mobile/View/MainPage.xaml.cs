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
            NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetTitleIcon(this, "icon.png");

            /*var buttonGroupTagCloudItems = new List<string>
            {
                "Lista",
                "Mapa"
            };
            listViews.Items.Add(new AccordionItem { Title = "CICLO DE DEBATES RETOMADA DO DESENVOLVIMENTO", Content = "em 30/11/2015", Images = "http://afrig.com.br/wp-content/uploads/ICMS3.jpg", IsSelected = true });
            listViews.Items.Add(new AccordionItem { Title = "INFORME PREVIDENCIARIO", Content = "em 30/11/2015", Images = "http://afrig.com.br/wp-content/uploads/ICMS3.jpg" });
            listViews.Items.Add(new AccordionItem { Title = "Item #3", Content = "em 30/11/2015", Images = "http://afrig.com.br/wp-content/uploads/ICMS3.jpg" });
            listViews.Items.Add(new AccordionItem { Title = "Item #3", Content = "em 30/11/2015", Images = "http://afrig.com.br/wp-content/uploads/ICMS3.jpg" });
            listViews.Items.Add(new AccordionItem { Title = "Item #3", Content = "em 30/11/2015", Images = "http://afrig.com.br/wp-content/uploads/ICMS3.jpg" });
            listViews.Items.Add(new AccordionItem { Title = "Item #3", Content = "em 30/11/2015", Images = "http://afrig.com.br/wp-content/uploads/ICMS3.jpg" });*/
            //bgButton.Items = buttonGroupTagCloudItems;
            //bgButton.ViewBackgroundColor = Color.FromHex("5ec8de");
            //bgButton.BackgroundColor = Color.FromHex("c8c8cd");
            //bgButton.Padding = new Thickness(5);
        }
    }
}
