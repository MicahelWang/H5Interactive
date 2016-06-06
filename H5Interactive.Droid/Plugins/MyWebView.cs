using System.Collections.Generic;
using System.Linq.Expressions;
using Android.Content;
using Android.Util;
using Android.Webkit;
using H5Interactive.Core.Utils;
using H5Interactive.Droid.Utils;

namespace H5Interactive.Droid.Plugins
{
    public sealed class MyWebView : WebView, IMvxWebView
    {
        public MyWebView(Context context) : base(context)
        {
            Settings.JavaScriptEnabled = true;
            this.SetWebViewClient(new MyWebViewClient());
        }

        public MyWebView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Settings.JavaScriptEnabled = true;
            Settings.DomStorageEnabled = true;
            Settings.SetAppCacheMaxSize(1024 * 1024 * 8);
            string appCachePath = context.ApplicationContext.CacheDir.AbsolutePath;
            Settings.SetAppCachePath(appCachePath);
            Settings.AllowFileAccess = (true);
            Settings.SetAppCacheEnabled(true);

            this.SetWebViewClient(new MyWebViewClient());
        }

        public new void Reload()
        {
            base.Reload();
        }
        public void ExcuteJs(string fnName, string options)
        {
            var json = string.Empty;
            if (!string.IsNullOrEmpty(options.Trim()))
            {
                json = options;
            }
            string javascriptCommand = $"javascript:{fnName}({json})";
            this.LoadUrl(javascriptCommand);
        }

        public string ScopeName { get; set; } = "AppJs";
        private IDictionary<string, IJavascriptCall> _calls;
        public IDictionary<string, IJavascriptCall> Calls
        {
            get { return _calls; }
            set
            {
                _calls = value;
                InitJavascriptInterface();
            }
        }

        private void InitJavascriptInterface()
        {
            if (ScopeName != "AppJs")
            {
                this.RemoveJavascriptInterface("AppJs");
            }
            JavaScriptEntity javaScript = new JavaScriptEntity(_calls);
            this.AddJavascriptInterface(javaScript, ScopeName);
        }
    }
}