using System;
using H5Interactive.Core.Utils;

namespace H5Interactive.Core.Entities
{
    public class JavaScriptCall : IJavascriptCall
    {
        private readonly Action<object> _callBack;

        public JavaScriptCall(Action<object> callBack)
        {
            this._callBack = callBack;
        }

        public void Call(string options)
        {
            _callBack(options);
        }
    }
}