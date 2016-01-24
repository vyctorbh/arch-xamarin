using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Mobile.Helper;
using Mobile.Droid;
using Android.Graphics;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace Mobile.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                //Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                var shape = new Android.Graphics.Drawables.ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Android.Graphics.Color.White;
                shape.Paint.StrokeWidth = 5;
                shape.Paint.SetStyle(Paint.Style.Stroke);

                Control.SetBackgroundDrawable(shape);
                Control.SetHintTextColor(Android.Content.Res.ColorStateList.ValueOf(global::Android.Graphics.Color.White));
            }
        }
    }
}