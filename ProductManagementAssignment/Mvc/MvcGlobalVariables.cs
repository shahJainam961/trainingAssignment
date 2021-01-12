using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace Mvc
{
    public class MvcGlobalVariables
    {
        public static HttpClient webapiclient = new HttpClient();

        static MvcGlobalVariables()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44379/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}