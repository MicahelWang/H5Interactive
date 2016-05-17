using H5Interactive.Core.Entities;
using UIKit;

namespace H5Interactive.Touch.Utils
{
    public class JavaScriptEntity
    {
        private readonly JavaScriptCollection _javaScriptCollection;
        private readonly UIWebView _webView;
        public JavaScriptEntity(UIWebView webView, JavaScriptCollection javaScriptCollection)
        {
            _webView = webView;
            _javaScriptCollection = javaScriptCollection;
        }

        public void Call(string key, string options)
        {
            if (_javaScriptCollection?.JavascriptCalls == null) return;
            if (!_javaScriptCollection.JavascriptCalls.ContainsKey(key)) return;
            _javaScriptCollection.JavascriptCalls[key].Call(options);
        }
        public void Call(string key)
        {
            Call(key, "");
        }
        public void Invoke(string key, string options)
        {
            if (_javaScriptCollection?.JavascriptInvokes == null) return;
            if (!_javaScriptCollection.JavascriptInvokes.ContainsKey(key)) return;
            var script= _javaScriptCollection.JavascriptInvokes[key].Invoke(options);
            _webView.EvaluateJavascript(script);
        }

        
        public void Invoke(string key)
        {
            Invoke(key, "");
        }
    }
}