using Android.Content;
using Com.Umeng.Analytics;
using H5Interactive.Core.Utils;

namespace H5Interactive.Droid.Utils
{
    public class StatisticsService:IStatisticsService
    {
        private const string PackName = "H5Interactive.Droid.H5Interactive.Droid";
        private const string Appkey = "56d93eeae0f55a7ef1002eb7";
        private const string ChannelId = "Umeng";
        private static Context _context;
        public static void Initialization(Context context)
        {
            _context = context;
            var config = new MobclickAgent.UMAnalyticsConfig(context, Appkey,ChannelId,MobclickAgent.EScenarioType.EUmNormal);
            MobclickAgent.StartWithConfigure(config);

        }

        
        private StatisticsService()
        {
            
        }

        private static StatisticsService _instance;
        public static StatisticsService Instance
        {
            get
            {
                if (_instance == null)
                    return _instance = new StatisticsService();
                else return _instance;
            }
        }


        public void OnPageEnd(string pageName)
        {
            MobclickAgent.OnPageEnd(pageName);
            
        }

        public void OnResume()
        {
            MobclickAgent.OnResume(_context);
        }

        public void OnPause()
        {
            MobclickAgent.OnPause(_context);
        }

        public void OnPageStart(string pageName)
        {
            MobclickAgent.OnPageStart(pageName);
        }



        public void ReportError(string msg)
        {
            MobclickAgent.ReportError(_context,msg);
        }


        public void OnEvent(string eventkey,string objs)
        {
            MobclickAgent.OnEvent(_context,eventkey,objs);
        }
    }
}