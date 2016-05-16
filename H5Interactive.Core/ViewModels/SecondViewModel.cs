using MvvmCross.Core.ViewModels;

namespace H5Interactive.Core.ViewModels
{
    public class SecondViewModel
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }
    }
}
