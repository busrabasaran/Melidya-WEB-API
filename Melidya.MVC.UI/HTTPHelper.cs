using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Melidya.MVC.UI
{
    public static class HTTPHelper
    {
        public static T SendRequest<T>(string host,string resource, Method httpMethod) 
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

       

    }
}