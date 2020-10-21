using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace webMvc.Helper
{
    public class UserApi
    {
        public HttpClient Initial()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:6001/api/Login/");
            return client;


        }
    }
}
