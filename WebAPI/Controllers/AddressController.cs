using Newtonsoft.Json;
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

        public dynamic Post([FromBody]Address address)
        {
            
            dynamic results;

            string a;

            try
            {
                a = Uri.EscapeDataString(address.Content);
                var uri = $"https://nominatim.openstreetmap.org/search.php?q={a}&format=json";
                var r = new WebClient().DownloadString(uri);
                dynamic g = JsonConvert.DeserializeObject<dynamic>(r);

               
                dynamic quality = GetAirQuality(g[0].lat, g[0].lon);
                dynamic weather = GetWeather(g[0].lat, g[0].lon);

                results = new
                {
                    airQuality = quality,
                    weatherInfo = weather
                };

                return JsonConvert.SerializeObject(results);
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }

        static dynamic GetAirQuality(dynamic lat, dynamic lon)
        {
            WebClient webClient = new WebClient();
            string latFormated = lat;
            latFormated = latFormated.Replace(",", ".");
            String lonFormated = lon;
            lonFormated = lonFormated.Replace(",", ".");
            return JsonConvert.DeserializeObject<dynamic>(webClient.DownloadString($"https://api.breezometer.com/baqi/?lat={latFormated}&lon={lonFormated}&key=3e3ca9627cd24faf8626cead119876ed").Trim());
        }

        static dynamic GetWeather(dynamic lat, dynamic lon)
        {
            WebClient webClient = new WebClient();
            string latFormated = lat;
            latFormated = latFormated.Replace(",", ".");
            String lonFormated = lon;
            lonFormated = lonFormated.Replace(",", ".");
            return JsonConvert.DeserializeObject<dynamic>(webClient.DownloadString($"https://api.worldweatheronline.com/premium/v1/weather.ashx?key=8988fd1c05984c27b8ce3bafdab57dd1&q={latFormated},{lonFormated}&num_of_days=1&tp=3&format=json").Trim());
        }
    }
}
