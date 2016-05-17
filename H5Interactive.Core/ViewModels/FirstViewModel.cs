using System.Collections.Generic;
using H5Interactive.Core.Entities;
using H5Interactive.Core.Utils;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace H5Interactive.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public IMvxWebView WebView { get; set; }
        public FirstViewModel()
        {
            var mvxCallPhone = Mvx.Resolve<MvvmCross.Plugins.PhoneCall.IMvxPhoneCallTask>();

            var users = new List<UserEntity>() {
                new UserEntity() { Name = "ÕÅÈý", Amount = 9999999, Phone = "18600012345" },
                new UserEntity() { Name = "Lucy", Amount = 8886, Phone = "1234" },
                new UserEntity() { Name = "Tom", Amount = 89898, Phone = "13558789541" } };
            _javascriptCalls = new Dictionary<string, IJavascriptCall>
            {
                {
                    "CallPhone", new JavaScriptCall(o => { mvxCallPhone.MakePhoneCall("", o.ToString()); })
                },
                {
                    "Show", new JavaScriptCall(o =>{WebView?.ExcuteJs("show", users.ToJson());})
                }
            };
        }
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }


        private IDictionary<string, IJavascriptCall> _javascriptCalls;
        public IDictionary<string, IJavascriptCall> JavascriptCalls
        {
            get { return _javascriptCalls; }
            set { SetProperty(ref _javascriptCalls, value); }
        }


    }
}
