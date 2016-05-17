using System.Collections.Generic;
using Android.Webkit;
using H5Interactive.Core.Entities;
using H5Interactive.Core.Utils;
using Java.Interop;

namespace H5Interactive.Droid.Utils
{
    public class JavaScriptEntity : Java.Lang.Object
    {
        private readonly IDictionary<string, IJavascriptCall> _javaScriptCollection;
        private readonly WebView _webView;
        public JavaScriptEntity(WebView webView, IDictionary<string, IJavascriptCall> javascriptCalls)
        {
            _webView = webView;
            _javaScriptCollection = javascriptCalls;
        }
        [Export]
        public void Call(string key, string options)
        {
            if (_javaScriptCollection == null) return;
            if (!_javaScriptCollection.ContainsKey(key)) return;
            _javaScriptCollection[key].Call(options);
        }
        [Export]
        public void Call(string key)
        {
            Call(key, "");
        }
    }
}