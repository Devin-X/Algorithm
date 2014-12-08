using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class WebRequestTest
    {
        public static void Test()
        {
        string endpoint = 
            "https://webservice.dns.bdm.microsoftonline.com/DNSService/DNSWebSvc.svc";

        HttpWebRequest webRequest = HttpWebRequest.CreateHttp(endpoint);

        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

        
        }
    }
}
