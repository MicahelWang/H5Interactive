using System.Collections.Generic;
using H5Interactive.Core.Entities;
using H5Interactive.Core.Utils;
using Java.Interop;

namespace H5Interactive.Droid.Utils
{
    public class JavaScriptEntity : Java.Lang.Object
    {
        private readonly IDictionary<string, IJavascriptCall> _javaScript;

        public JavaScriptEntity(IDictionary<string, IJavascriptCall> javascriptCalls)
        {
            _javaScript = javascriptCalls;
        }
        [Export]
        public void Call(string key, string options)
        {
            if (_javaScript == null) return;
            if (!_javaScript.ContainsKey(key)) return;
            _javaScript[key].Call(options);
        }
        [Export]
        public void Call(string key)
        {
            Call(key, "");
        }
    }
}