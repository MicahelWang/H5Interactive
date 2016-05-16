using Android.App;
using Android.OS;
using H5Interactive.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace H5Interactive.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class SecondView : MvxActivity<SecondViewModel>
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}