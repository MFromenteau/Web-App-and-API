using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class Address
    {
        public string Content { get; set; }
    }

    public class AddressController : ApiController
    {

        public string Post([FromBody]Address address)
        {
            string results;
            string a;

            try
            {
                results = $"Results from API : {address.Content}";
                return results;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
    }
}
