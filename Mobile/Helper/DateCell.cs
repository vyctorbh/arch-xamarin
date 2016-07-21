using System;
using Xamarin.Forms;

namespace Mobile
{
	public class DateCell : ViewCell
	{
		private readonly DatePicker but;

		public DateCell()
		{
			but = new DatePicker()
			{
				Format = "dd/MM/yyyy",
				WidthRequest = 400,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			var layout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					but
				}
			};

			this.View = layout;
		}

		public DatePicker ButtonControl
		{
			get
			{
				return but;
			}
		}
	}

	public class KeyValueCell : ViewCell
	{
		public string keys
		{
			get;
			set;
		}

		public string values
		{
			get;
			set;
		}

		public KeyValueCell()
		{
			View = new StackLayout()
			{
				Padding = new Thickness(15, 10),
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label () {
						Text = keys,
						TextColor = Color.Purple,
						HorizontalOptions = LayoutOptions.StartAndExpand
					},
					new Label () {
						Text = values,
						TextColor = Color.Gray,
						HorizontalOptions = LayoutOptions.EndAndExpand
					}
				}
			};
		}
	}

}

