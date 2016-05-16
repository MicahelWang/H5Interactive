using System.Collections.Generic;
using Android.Webkit;
using H5Interactive.Core.Utils;
using Java.Interop;

namespace H5Interactive.Droid.Utils
{
    public class JavaScriptEntity : Java.Lang.Object
    {
        private readonly IDictionary<string, IJavascriptInvoke> _invokeCollection;
        private readonly IDictionary<string, IJavascriptCall> _callCollection;
        private readonly WebView _webView;
        public JavaScriptEntity(WebView webView, IDictionary<string, IJavascriptInvoke> invokeCollection, IDictionary<string, IJavascriptCall> callCollection)
        {
            _invokeCollection = invokeCollection;
            _callCollection = callCollection;
            _webView = webView;
        }
        [Export]
        public void Call(string key, string options)
        {
            if (!_callCollection.ContainsKey(key)) return;
            _callCollection[key].Call(options);
        }
        [Export]
        public void Call(string key)
        {
            Call(key, "");
        }
        [Export]
        public void Invoke(string key, string options)
        {
            if (!_invokeCollection.ContainsKey(key)) return;
            var url = _invokeCollection[key].Invoke(options);
            _webView.LoadUrl(url);
        }

        [Export]
        public void Invoke(string key)
        {
            Invoke(key, "");
        }
    }
}