using System;
using System.Collections.Generic;
using Foundation;
using H5Interactive.Core.Utils;
using UIKit;

namespace H5Interactive.Touch.Delegates
{
    public class MyWebViewDelegate : UIWebViewDelegate
    {
        private readonly UIActivityIndicatorView _activity;

        public IDictionary<string, IJavascriptCall> Calls { get; set; }


        private MyWebViewDelegate(UIActivityIndicatorView activityIndicatorView)
        {
            this._activity = activityIndicatorView;
        }

        public MyWebViewDelegate() : this(null)
        {

        }


        public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            
            var prefix = "DingDingIos";
            if (string.Equals(request.Url.Scheme, prefix, StringComparison.CurrentCultureIgnoreCase))
            {
                var str = request.Url.ResourceSpecifier.Remove(0,2);
                var resutl = str.Split('/');
                if (Calls != null)
                {
                    var key = resutl[0];
                    var option = resutl[1];
                    if (Calls.ContainsKey(key))
                    {
                        Calls[key].Call(option);
                        return false;
                    }
                }
            }
            return true;
        }
        
        public override void LoadStarted(UIWebView webView)
        {
            if (_activity == null) return;
            //base.LoadStarted(webView);
            _activity.Hidden = false;
            _activity.StartAnimating();
        }

        public override void LoadingFinished(UIWebView webView)
        {
            if (_activity == null) return;
            _activity.Hidden = true;
            _activity.StopAnimating();
        }

        public override void LoadFailed(UIWebView webView, NSError error)
        {
            //base.LoadFailed(webView, error);
            if (_activity != null)
            {
                _activity.Hidden = true;
                _activity.StopAnimating();
            }
            var alert = new UIAlertView
            {
                Title = "类型加载出错"
            };
            alert.AddButton("Cacel");
            alert.Show();
        }
    }
}