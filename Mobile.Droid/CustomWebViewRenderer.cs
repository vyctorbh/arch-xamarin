using System;
using Xamarin.Forms;
using Mobile;
using Mobile.Droid;
using Xamarin.Forms.Platform.Android;
using System.Net;
using Xam.Plugin.DownloadManager.Droid;

[assembly: ExportRenderer (typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace Mobile.Droid
{
	public class CustomWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<WebView> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement != null) {
				var customWebView = Element as CustomWebView;
				Control.Settings.AllowUniversalAccessFromFileURLs = true;
				var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				//DownloadManager webClient = new DownloadManager();
				//webClient.Download("http://www.afrig.com.br/wp-content/uploads/2016/05/Boletim-20-05-2016.pdf", documentsPath+"/Test.pdf"); // Download Using HttpWebRequest
				//Control.LoadUrl (string.Format ("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format ("file:///android_asset/Content/Test.pdf", WebUtility.UrlEncode (customWebView.Uri))));
				Control.LoadUrl (string.Format ("https://docs.google.com/viewer?url={0}", customWebView.Uri));
			}
		}
	}
}

