using IdentityModel.Client;
using IdentityServer.WebApi.Client.Models;
using IdentityServer.WebApi.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.WebApi.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IIdentityServer4Service _identityServer4Service = null;
        public WeatherController(IIdentityServer4Service identityServer4Service)
        {
            _identityServer4Service = identityServer4Service;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForeCast>> Get()
        {
            var OAuth2Token = await _identityServer4Service.GetToken("ltv.read");
            using (var client = new HttpClient())
            {
                client.SetBearerToken(OAuth2Token.AccessToken);
                var result = await client.GetAsync("https://localhost:44345/WeatherForecast");
                if (result.IsSuccessStatusCode)
                {
                    var model = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<WeatherForeCast>>(model);
                }
                else
                {
                    throw new Exception("Some error while fetching data");
                }
            }
        }
    }
}
