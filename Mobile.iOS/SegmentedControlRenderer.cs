using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(Mobile.Helper.SegmentedControl), typeof(Mobile.iOS.SegmentedControlRenderer))]
namespace Mobile.iOS
{
	public class SegmentedControlRenderer : ViewRenderer<Mobile.Helper.SegmentedControl, UISegmentedControl>
	{
		public SegmentedControlRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Mobile.Helper.SegmentedControl> e)
		{
			base.OnElementChanged(e);

			var segmentedControl = new UISegmentedControl();
			segmentedControl.TintColor = UIColor.FromRGB(248, 248, 245);

			for (var i = 0; i < e.NewElement.Children.Count; i++)
			{
				segmentedControl.InsertSegment(e.NewElement.Children[i].Text, i, false);
			}

			segmentedControl.ValueChanged += (sender, eventArgs) =>
			{
				e.NewElement.SelectedValue = segmentedControl.TitleAt(segmentedControl.SelectedSegment);
			};

			SetNativeControl(segmentedControl);
		}
	}
}

