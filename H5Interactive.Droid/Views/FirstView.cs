//using System;

using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Android.Widget;
using H5Interactive.Core.Entities;
using H5Interactive.Core.Utils;
using H5Interactive.Droid.Utils;
using MvvmCross.Droid.Views;

namespace H5Interactive.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            var webView = FindViewById<WebView>(Resource.Id.webView1);
            var btnReload = FindViewById<Button>(Resource.Id.btnReload);
            btnReload.Click += delegate
            {
                webView.Reload();
            };
            webView.Settings.JavaScriptEnabled = true;
            var url = "http://192.168.1.87/main.html";
            webView.LoadUrl(url);
            var users = new List<UserEntity>() {
                new UserEntity() { Name = "ÕÅÈý", Amount = 9999999, Phone = "18600012345" },
                new UserEntity() { Name = "Lucy", Amount = 8886, Phone = "1234" },
                new UserEntity() { Name = "Tom", Amount = 89898, Phone = "13558789541" } };
            IDictionary<string, IJavascriptInvoke> invokeCollection = new Dictionary<string, IJavascriptInvoke>();
            IDictionary<string, IJavascriptCall> callCollection = new Dictionary<string, IJavascriptCall>();
            invokeCollection.Add("show", new JavaScriptInvoke("show", users));
            callCollection.Add("CallPhone", new JavaScriptCall(o =>
            {
                CallPhone(o.ToString());
            }));

            var jsEnttiy = new JavaScriptEntity(webView, invokeCollection, callCollection);
            webView.AddJavascriptInterface(jsEnttiy, "contact");

        }

        private void CallPhone(string phone)
        {
            StartActivity(new Intent(Intent.ActionCall, Android.Net.Uri.Parse("tel:" + phone)));
        }

    }


}
