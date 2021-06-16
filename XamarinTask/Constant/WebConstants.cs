using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTask
{
    static partial class WebConstants
    {
        private static string apiKey = "56bff2fcbc554686962801c22a9baee8";
        public static string ArticlesUrl = "https://newsapi.org/v1/articles?source=the-next-web&apiKey="+apiKey;
    }
}
