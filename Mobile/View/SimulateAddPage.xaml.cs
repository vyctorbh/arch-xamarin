using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;
using Telerik.XamarinForms.Input.DataForm;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.Common.DataAnnotations;
using Telerik.XamarinForms.Input;

namespace Mobile
{
	public partial class SimulateAddPage : PopupPage
	{
		public SimulateAddPage()
		{
			InitializeComponent();
			this.AnimationName = Rg.Plugins.Popup.Enums.AnimationsName.MoveBottom;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		private void OnClose(object sender, EventArgs e)
		{
			PopupNavigation.PopAsync();
		}

		protected override bool OnBackButtonPressed()
		{
			// Prevent hide popup
			//return base.OnBackButtonPressed();
			return true;
		}
	}
}

