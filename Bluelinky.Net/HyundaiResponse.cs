using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bluelinky.Net
{
    /// <summary>
    /// Response model of the http requests
    /// </summary>
    /// <typeparam name="T">Result model</typeparam>
    public class HyundaiResponse<T>
    {
        /// <summary>
        /// Status of the response
        /// </summary>
        public string Status { get; private set; }
        /// <summary>
        /// Result if the response is success
        /// </summary>
        public T Result { get; private set; }
        /// <summary>
        /// Error message if the response failed
        /// </summary>
        public string ErrorMessage { get; private set; }
    }


    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; private set; }
        [JsonProperty("username")]
        public string Username { get; private set; }
    }


}
