using System;
using System.Collections.Generic;
using Foundation;
using H5Interactive.Core.Utils;
using H5Interactive.Touch.Delegates;
using UIKit;

namespace H5Interactive.Touch.Plugins
{
    public sealed class MyWebView:UIWebView,IMvxWebView
    {
       
        private readonly MyWebViewDelegate _myWebViewDelegate;
        public MyWebView(string urlAddress):this(urlAddress,null)
        {
        }

        public MyWebView(string urlAddress, IDictionary<string, IJavascriptCall> calls)
        {
            _myWebViewDelegate = new MyWebViewDelegate();
            this.Delegate = _myWebViewDelegate;
            Calls = calls;
            NSUrl url = new NSUrl(urlAddress);
            NSUrlRequest urlRequest = new NSUrlRequest(url);
            LoadRequest(urlRequest);
            ScalesPageToFit = true;
        }

        public void ExcuteJs(string fnName,string options)
        {
            var json = string.Empty;
            if (!string.IsNullOrEmpty(options.Trim()))
            {
                json = options;
            }
            var script = String.Format(@"{0}({1})", fnName, json);
            this.EvaluateJavascript(script);
        }
        private IDictionary<string, IJavascriptCall> _calls;
        public IDictionary<string, IJavascriptCall> Calls
        {
            get { return _calls; }
            set
            {
                _calls = value;
                _myWebViewDelegate.Calls = _calls;
            }
        }
    }
}