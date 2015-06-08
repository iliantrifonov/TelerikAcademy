using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceRequester
{
    class HttpRequester
    {
        internal const string VALID_PASSWORD = "AAaa#123456";
        private HttpClient client;

        public HttpRequester()
        {
            this.client = new HttpClient();
        }

        public class LoginResponceModel
        {
            public string access_token { get; set; }
            //public string token_type { get; set; }
            //public int expires_in { get; set; }
            //public string userName { get; set; }
        }

        public string RegisterUserAndGetSessionKey(string email, string urlRegister, string urlLogin, string mediaType = "application/x-www-form-urlencoded")
        {
            // register;
            this.Post(urlRegister, "Email=" + email + "&Password=" + VALID_PASSWORD + "&ConfirmPassword=" + VALID_PASSWORD, mediaType);
            // login;
            HttpResponseMessage response = this.Post(urlLogin, "Username=" + email + "&Password=" + VALID_PASSWORD + "&grant_type=password", mediaType);
            string result = response.Content.ReadAsStringAsync().Result;
            LoginResponceModel loginModel = JsonConvert.DeserializeObject<LoginResponceModel>(result);
            return loginModel.access_token;
        }

        public HttpResponseMessage Get(string url, string mediaType = "application/json", bool authRequired = false, string sessionKey = "no_key_sent")
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);

            request.Method = HttpMethod.Get;

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            if (authRequired)
            {
                request.Headers.Add(Authorization, Bearer + " " + sessionKey);
            }

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response;
        }

        public HttpResponseMessage Post(string url, string data, string mediaType = "application/json", bool authRequired = false, string sessionKey = "no_key_sent")
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);

            request.Method = HttpMethod.Post;

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Content = new StringContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            if (authRequired)
            {
                request.Headers.Add(Authorization, Bearer + " " + sessionKey);
            }

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response;
        }
        private const string Authorization = "Authorization";

        private const string Bearer = "Bearer";

        public HttpResponseMessage Put(string url, string data, string mediaType = "application/json", bool authRequired = false, string sessionKey = "no_key_sent")
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Put;

            request.Content = new StringContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            if (authRequired)
            {
                request.Headers.Add(Authorization, Bearer + " " + sessionKey);
            }

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response;
        }

    }
}