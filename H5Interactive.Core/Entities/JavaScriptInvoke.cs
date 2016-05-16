using System;
using System.Collections.Generic;
using H5Interactive.Core.Utils;

namespace H5Interactive.Core.Entities
{
    public class JavaScriptInvoke : IJavascriptInvoke
    {
        private readonly string _fnName;
        private object _args;
        private readonly Func<object, object> _callBack;

        public JavaScriptInvoke(string fnName)
        {
            this._fnName = fnName;
        }
        public JavaScriptInvoke(string fnName,object args)
        {
            this._fnName = fnName;
            this._args = args;
        }
        public JavaScriptInvoke(string fnName,Func<object,object> callBack )
        {
            this._fnName = fnName;
            this._callBack = callBack;
        }
        public string Invoke(string options)
        {
            string json = string.Empty;
            if (_callBack != null)
            {
                _args = _callBack(options);
            }
            if (_args!= null)
            {
                json = _args.ToJson();
            }
            string javascriptCommand = $"javascript:{_fnName}({json})";
            // 调用JS中的方法
            return javascriptCommand;
        }
       
    }

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