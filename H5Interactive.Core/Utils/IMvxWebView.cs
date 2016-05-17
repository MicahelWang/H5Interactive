using System.Collections.Generic;

namespace H5Interactive.Core.Utils
{
    public interface IMvxWebView
    {
        /// <summary>
        /// 执行Js
        /// </summary>
        /// <param name="fnName">方法名</param>
        /// <param name="options">参数</param>
        void ExcuteJs(string fnName,string options);
        IDictionary<string,IJavascriptCall> Calls { get; set; } 
    }
}