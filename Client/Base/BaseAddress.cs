using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Base
{
    public class BaseAddress
    {
        public string Url()
        {
            string url = "https://localhost:44373/api/";
            return url;
        }
    }
}