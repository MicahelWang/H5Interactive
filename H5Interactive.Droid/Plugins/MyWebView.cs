﻿using System.Collections.Generic;
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
            this.SetWebViewClient(new MyWebViewClient());
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

        private IDictionary<string, IJavascriptCall> _calls;
        public IDictionary<string, IJavascriptCall> Calls
        {
            get { return _calls; }
            set
            {
                _calls = value;
                JavaScriptEntity javaScript = new JavaScriptEntity(_calls);
                this.AddJavascriptInterface(javaScript, "contact");
            }
        }
    }

    public class MyWebViewClient: WebViewClient
    {

        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}