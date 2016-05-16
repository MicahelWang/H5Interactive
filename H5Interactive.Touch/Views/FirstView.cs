using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Foundation;
using UIKit;
using CoreGraphics;
using System;
using System.Drawing;

namespace H5Interactive.Touch.Views
{
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {
        }
		int _heigt = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(Label).To(vm => vm.Hello);
            set.Bind(TextField).To(vm => vm.Hello);
			_heigt = 140;
			var button = AddButton ("Reload");

			var webView = AddWebView ();
			var urlAddress = "http://Xamarin.com";
			NSUrl url = new NSUrl (urlAddress);
			NSUrlRequest requestObj = new NSUrlRequest (url);
			webView.LoadRequest (requestObj);
			button.TouchUpInside += delegate {
				webView.Reload ();
				var alert = UIAlertController.Create ("Warnning", "Hello ", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("OK",UIAlertActionStyle.Default,null));
				PresentViewController(alert,true,null);
			};
			set.Apply();
        }

		private UIButton AddButton (string title)
		{
			var button = new UIButton (UIButtonType.RoundedRect);
			button.Frame = new RectangleF (10, 10+_heigt, 300, 40);
			_heigt = 10+_heigt + 40;
			button.SetTitle (title, UIControlState.Normal);
			Add (button);
			return button;
		}
		private UIWebView AddWebView ()
		{
			var currentHeight = 10 + _heigt;
			var screenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			var screenHeight = (int)UIScreen.MainScreen.Bounds.Height;
			UIWebView webView = new UIWebView ();
			webView.Frame = new RectangleF (10,currentHeight, screenWidth - 20, screenHeight - currentHeight);

			webView.ScalesPageToFit = true;
			Add(webView);
			_heigt = screenHeight;
			return webView;
		}
    }
}
