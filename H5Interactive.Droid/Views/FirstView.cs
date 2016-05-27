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
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            var webView = FindViewById<MyWebView>(Resource.Id.webView1);
            this.ViewModel.WebView = webView;
            var url = "http://192.168.1.87/main.html";
            webView.Calls = ViewModel.JavascriptCalls;
            webView.LoadUrl(url);

        }

    }


}
