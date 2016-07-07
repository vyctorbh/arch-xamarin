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
		private object person = new Book();

		public SimulateAddPage()
		{
			InitializeComponent();
			this.AnimationName = Rg.Plugins.Popup.Enums.AnimationsName.MoveBottom;
			this.BindingContext = this.person;

			this.dataForm.PropertyDataSourceProvider = new UserPropertyDataSourceProvider();
			this.dataForm.ValidationMode = ValidationMode.OnLostFocus;
			this.dataForm.CommitMode = CommitMode.Manual;

			this.dataForm.RegisterEditor("Name", EditorType.TextEditor);
			this.dataForm.RegisterEditor("Genre", EditorType.PickerEditor);
			this.dataForm.RegisterEditor("TargetGroup", EditorType.SegmentedEditor);
			this.dataForm.RegisterEditor("Year", EditorType.NumberPickerEditor);
			this.dataForm.RegisterEditor("Rating", EditorType.SliderEditor);
			this.dataForm.RegisterEditor("IsPublished", EditorType.CheckBoxEditor);
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

		private async void DataFormValidationCompleted(object sender, FormValidationCompletedEventArgs e)
		{
			this.dataForm.FormValidationCompleted -= this.DataFormValidationCompleted;
			if (e.IsValid)
			{
				await this.DisplayAlert("Success", "Book was successfully updated.", "OK");
			}
			else
			{
				await this.DisplayAlert("Fail", string.Format("There are some invalid fields."), "OK");
			}
		}

		private void CommitButtonButtonClicked(object sender, EventArgs e)
		{
			this.dataForm.FormValidationCompleted += this.DataFormValidationCompleted;
			this.dataForm.CommitAll();
		}
	}

	public enum TargetAudience
	{
		Child,
		Teenager,
		Adult,
		Universal
	}

	public class Book : NotifyPropertyChangedBase
	{
		private string name;
		private string genre;
		private TargetAudience targetGroup;
		private double year = 1990;
		private bool isPublished;
		private float rating;
		private DateTime lastReviewed = new DateTime(2010, 11, 3);

		[DisplayOptions(Header = "Name", PlaceholderText = "Book Name", Position = 0)]
		[StringLengthValidator(2, int.MaxValue, "Name should be longer than 2 symbols.")]
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
					this.RaisePropertyCanged();
				}
			}
		}

		[DisplayOptions(Header = "Genre", PlaceholderText = "Select Genre", Position = 1)]
		[DataSourceKey("Genre")]
		public string Genre
		{
			get
			{
				return this.genre;
			}
			set
			{
				if (this.genre != value)
				{
					this.genre = value;
					this.RaisePropertyCanged();
				}
			}
		}

		[DisplayOptions(Header = "Target Group", Position = 2)]
		public TargetAudience TargetGroup
		{
			get
			{
				return this.targetGroup;
			}
			set
			{
				if (this.targetGroup != value)
				{
					this.targetGroup = value;
					this.RaisePropertyCanged();
				}
			}
		}

		[DisplayOptions(Header = "Year", Position = 3)]
		[NumericalRangeValidator(1990, 2015, 1)]
		public double Year
		{
			get
			{
				return this.year;
			}
			set
			{
				if (this.year != value)
				{
					this.year = value;
					this.RaisePropertyCanged();
				}
			}
		}

		[DisplayOptions(Header = "Publish", Position = 4)]
		public bool IsPublished
		{
			get
			{
				return this.isPublished;
			}
			set
			{
				if (this.isPublished != value)
				{
					this.isPublished = value;
					this.RaisePropertyCanged();
				}
			}
		}

		[DisplayOptions(Header = "Rating", Position = 7)]
		[NumericalRangeValidator(0, 5, 1)]
		public float Rating
		{
			get
			{
				return this.rating;
			}
			set
			{
				if (this.rating != value)
				{
					this.rating = value;
					this.RaisePropertyCanged();
				}
			}
		}
	}

	public class UserPropertyDataSourceProvider : PropertyDataSourceProvider
	{
		public override IList GetSourceForKey(object key)
		{
			if (key.Equals("Genre"))
			{
				return new List<string>
				{
					"Comedy",
					"Drama",
					"Non Fiction",
					"Realistic Fiction",
					"Romance",
					"Satire",
					"Tragedy",
					"Tragicomedy"
				};
			}

			return null;
		}
	}
}

