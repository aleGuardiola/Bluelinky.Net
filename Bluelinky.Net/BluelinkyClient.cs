using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Pathoschild.Http.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bluelinky.Net
{
    public class BluelinkyClient
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        private string _username, _password;

        private DateTime TokenExpires;
        private string AccessToken;
        private string RefreshToken;

        FluentClient _httpClient;

        public BluelinkyClient(string username, string password, HttpClient httpClient = null)
        {
            _username = username;
            _password = password;
            _httpClient = new FluentClient("https://owners.hyundaiusa.com", httpClient);
        }

        public async Task LoginAsync()
        {
            var response = await GetTokenAsync();

            var currentTime = DateTime.Now;

            TokenExpires = currentTime + TimeSpan.FromSeconds(response.ExpiresIn);
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
        }

        
        private async Task<TokenResponse> GetTokenAsync()
        {
            var now = DateTime.Now.Second;
            var response = await _httpClient.GetAsync($"{Endpoints.GetToken}{now}").As<dynamic>();
            
            var csrfToken = (string)response.token;

            response = await _httpClient.GetAsync(Endpoints.ValidateToken)
                                        .WithHeader("Cookie", $"csrf_token={csrfToken}")
                                        .As<dynamic>();

            var multiPart = new MultipartFormDataContent();

            multiPart.Add(new StringContent(csrfToken), ":cq_csrf_token");
            multiPart.Add(new StringContent(_username), "username");
            multiPart.Add(new StringContent(_password), "password");
            multiPart.Add(new StringContent("https://owners.hyundaiusa.com/us/en/index.html"), "url");
            
            var strResponse = await _httpClient.PostAsync(Endpoints.Auth)
                                               //.WithHeader("Cookie", $"csrf_token={csrfToken}")
                                               .WithBody(multiPart).AsString();//.As<string>();

            var responseJson = JsonConvert.DeserializeObject<dynamic>(strResponse);
            var tokenJObj = (JObject)responseJson.Token;

            return tokenJObj.ToObject<TokenResponse>();
        }        
    }
}
