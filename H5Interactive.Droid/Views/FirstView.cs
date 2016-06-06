//using System;

using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Android.Widget;
using H5Interactive.Core.Entities;
using H5Interactive.Core.Utils;
using H5Interactive.Core.ViewModels;
using H5Interactive.Droid.Plugins;
using H5Interactive.Droid.Utils;
using MvvmCross.Droid.Views;

namespace H5Interactive.Droid.Views
{
    [Activity(Label = "View for FirstViewModel",Theme = "@style/Theme.DefaultStyle")]
    public class FirstView : BaseView<FirstViewModel>
    {
        private MyWebView _webView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            _webView = FindViewById<MyWebView>(Resource.Id.webView1);
            this.ViewModel.WebView = _webView;
            var url = ViewModel.Url;
            _webView.Calls = ViewModel.JavascriptCalls;
            _webView.LoadUrl(url);

        }

       
    }


}
