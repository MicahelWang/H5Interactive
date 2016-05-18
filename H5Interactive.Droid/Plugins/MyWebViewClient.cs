using Android.Webkit;

namespace H5Interactive.Droid.Plugins
{
    public class MyWebViewClient: WebViewClient
    {

        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}