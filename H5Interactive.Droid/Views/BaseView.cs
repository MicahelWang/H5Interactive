using Android.OS;
using H5Interactive.Core.Utils;
using H5Interactive.Droid.Utils;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace H5Interactive.Droid.Views
{
    public class BaseView<TViewModel> : MvxActivity<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected IStatisticsService Statistics;
        protected string PageName;
        public BaseView()
        {
            //Statistics=Mvx.Resolve<IStatisticsService>();
            PageName = this.Title;
        }
        protected override void OnResume()
        {
            //Statistics.OnResume();
            //Statistics.OnPageStart(PageName);
            base.OnResume();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void OnPause()
        {
            //Statistics.OnPageEnd(PageName);
            base.OnPause();
        }


    }
}