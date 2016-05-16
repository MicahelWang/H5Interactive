using System;
using Android.Content;
using Android.Net;
using Android.Webkit;
using H5Interactive.Core.Utils;
using Java.Interop;

namespace H5Interactive.Droid.Utils
{
    public sealed class Contact : Java.Lang.Object
    {
        private readonly object _args;
        private readonly WebView _currentWebView;
        private readonly string _functionName;

        private readonly Context _context;

        public void Excute(Action callBack)
        {
            callBack();
        }

        public void BeCall(string functionName, object args)
        {
            var options = string.Empty;
            var obj = args as string;
            if (obj != null)
            {
                options = args.ToString();
            }
            else
            {
                if (_args == null)
                {
                    options = _args.ToJson();
                }
            }
            string javascriptCommand = $"javascript:{_functionName}({options})";
            // 调用JS中的方法
            _currentWebView.LoadUrl(javascriptCommand);
        }

        public Contact(Context context,WebView currentWebView, string functionName) : this(context,currentWebView, functionName, null)
        {

        }

        public Contact(Context context,WebView currentWebView, string functionName, object args)
        {
            _args = args;
            _context = context;
            _currentWebView = currentWebView;
            _functionName = functionName;
        }
        [Export]
        public void Call(string phone)
        {
            _context.StartActivity(new Intent(Intent.ActionCall, Android.Net.Uri.Parse("tel:" + phone)));
        }
        [Export]
        public void ShowContacts()
        {
            var options = string.Empty;
            var obj = _args as string;
            if (obj != null)
            {
                options = _args.ToString();
            }
            else
            {
                if (_args != null)
                {
                    options = _args.ToJson();
                }
            }
            string javascriptCommand = $"javascript:{_functionName}({options})";
            // 调用JS中的方法
            _currentWebView.LoadUrl(javascriptCommand);
        }
    }
}