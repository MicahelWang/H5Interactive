using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Umeng.Analytics;
using H5Interactive.Core.Utils;
using H5Interactive.Droid.Utils;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace H5Interactive.Droid
{
    [Activity(
        Label = "@string/ApplicationName"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StatisticsService.Initialization(this.ApplicationContext);
            Mvx.LazyConstructAndRegisterSingleton<IStatisticsService>(() => StatisticsService.Instance);
        }
    }
}
