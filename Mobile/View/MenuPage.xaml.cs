using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class MenuPage : BasePage
    {
		readonly List<OptionItem> OptionItems = new List<OptionItem>();

        public MenuPage()
        {
            InitializeComponent();
			OptionItems.Add(new OptionItem() { Title = "Projeções" });
			OptionItems.Add(new OptionItem() { Title = "Sobre" });
			OptionItems.Add(new OptionItem() { Title = "Logout" });
			var cell = new DataTemplate(typeof(DarkTextCell));
			cell.SetBinding(TextCell.TextProperty, "Title");
			cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
			cell.SetValue(TextCell.TextColorProperty, "#F8F8F8");
			cell.SetValue(VisualElement.BackgroundColorProperty, Color.Transparent);
			listMenu.ItemTemplate = cell;
			listMenu.ItemsSource = OptionItems;
        }
    }
	public class DarkTextCell : ImageCell { }

	public class OptionItem
	{
		public string Title { get; set;}
		public int Count { get; set; }
		public bool Selected { get; set; }
		public string Icon { get { return Title.ToLower().TrimEnd('s') + ".png"; } }
		public ImageSource IconSource { get { return ImageSource.FromFile(Icon); } }
	}
}
