using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.Net;
using System.IO;
using UIKit;
using Mobile.Helper;
using Mobile.iOS;
using Foundation;
using Mobile;
using System;

[assembly: ExportRenderer (typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace Mobile.iOS
{
	public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
	{
		protected override void OnElementChanged (ElementChangedEventArgs<CustomWebView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new UIWebView ());
			}
			if (e.OldElement != null) {
				// Cleanup
			}
			if (e.NewElement != null) {
				Uri url = new Uri("http://www.afrig.com.br/wp-content/uploads/2016/05/Boletim-20-05-2016.pdf");
				var webClient = new WebClient();
				webClient.DownloadStringCompleted += (s, ee) => {
					var customWebView = Element as CustomWebView;
					var text = ee.Result; // get the downloaded text
					string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					string localFilename = customWebView.Uri;
					string localPath = Path.Combine (documentsPath, localFilename);
					File.WriteAllText (localPath, text); // writes to local storage
				};
				webClient.DownloadStringAsync(url);

				//var customWebView = Element as CustomWebView;
				//string fileName = Path.Combine (NSBundle.MainBundle.BundlePath, string.Format ("Content/{0}", WebUtility.UrlEncode (customWebView.Uri)));
				//Control.LoadRequest (new NSUrlRequest (new NSUrl (fileName, false)));
				//Control.ScalesPageToFit = true;
			}
		}
	}
}

