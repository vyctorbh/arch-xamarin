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
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
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

}

