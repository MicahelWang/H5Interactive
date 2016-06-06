using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using CoreGraphics;
using System.Drawing;
using H5Interactive.Core.ViewModels;
using H5Interactive.Touch.Plugins;

namespace H5Interactive.Touch.Views
{
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView() : base("FirstView", null)
        {
            
        }
        int _heigt = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationController.NavigationBar.Hidden = true;
            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            //var button = AddButton("Reload");
            var urlAddress = ViewModel.Url;
            var webView = AddWebView(urlAddress);
            this.ViewModel.WebView = webView;

            //button.TouchUpInside += delegate
            //{
            //    webView.Reload();
            //};
            set.Apply();
        }

        private UIButton AddButton(string title)
        {
            var button = new UIButton(UIButtonType.RoundedRect) { Frame = new RectangleF(10, 10 + _heigt, 300, 40) };
            _heigt = 10 + _heigt + 40;
            button.SetTitle(title, UIControlState.Normal);
            Add(button);
            return button;
        }
        private MyWebView AddWebView(string urlAddress)
        {
            var currentHeight = _heigt;
            var screenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            var screenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            MyWebView webView = new MyWebView(urlAddress,ViewModel.JavascriptCalls)
            {
                Frame = new RectangleF(0, currentHeight, screenWidth, screenHeight - currentHeight),
                ScalesPageToFit = true
            };
            Add(webView);
            _heigt = currentHeight+10;
            return webView;
        }
    }
}
