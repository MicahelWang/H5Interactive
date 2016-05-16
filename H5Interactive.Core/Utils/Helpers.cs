using Newtonsoft.Json;

namespace H5Interactive.Core.Utils
{
    public static class Helpers
    {
        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source);
        }
    }
}