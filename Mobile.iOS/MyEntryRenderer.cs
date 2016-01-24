using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Mobile.Helper;
using Mobile.iOS;
using Foundation;


[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace Mobile.iOS
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                Control.BackgroundColor = UIColor.Clear;
                Control.BorderStyle = UITextBorderStyle.None;
                //this.Layer.BorderWidth = 1.3f;
                //this.Layer.CornerRadius = 15f;
                //this.Layer.BorderColor = UIColor.White.CGColor;
                //Control.TextColor = UIColor.White;
                NSAttributedString placeholderString = new NSAttributedString(Control.Placeholder, new UIStringAttributes() { ForegroundColor = UIColor.White });
                Control.AttributedPlaceholder = placeholderString;
            }
        }
    }
}