namespace H5Interactive.Core.Utils
{
    public interface IStatisticsService
    {
        void OnPageEnd(string pageName);

        void OnResume();
        void OnPause();

        void OnPageStart(string pageName);

        void ReportError(string msg);

        void OnEvent(string eventkey, string objs);
    }
}