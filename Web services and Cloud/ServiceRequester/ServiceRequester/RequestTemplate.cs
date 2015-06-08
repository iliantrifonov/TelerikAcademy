using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequester
{
    class RequestTemplate
    {
        internal static List<String> SessionKeys = new List<string>();

        public RequestTemplate(
            RequestType type, 
            string address,
            bool authRequired, 
            string mediaType = "application/json", 
            string body = "", 
            int userNumber = 0,
            string comments = "// nothing special here...") 
        {
            this.Type = type;
            this.Address = address;
            this.AuthenticationRequired = authRequired;
            this.MediaType = mediaType;
            this.Body = body;
            this.UserNumber = userNumber;
            this.Comments = comments;
        }

        internal RequestType Type { get; set; }
        internal string Address { get; set; }
        internal bool AuthenticationRequired { get; set; }
        internal string Body { get; set; }
        internal string MediaType { get; set; }
        internal int UserNumber { get; set; }
        internal string Comments { get; set; }

        internal string ResponseCode { get; set; }
        internal string ResponseBody { get; set; }

        public string SessionKey 
        {
            get { return SessionKeys[this.UserNumber]; }
        }

        public void GetResponseFromServer() 
        {
            var requester = new HttpRequester();

            HttpResponseMessage response;
            switch (this.Type)
            {
                case RequestType.Post:
                    response = requester.Post(this.Address, this.Body, this.MediaType, this.AuthenticationRequired, this.SessionKey);
                    break;
                case RequestType.Put:
                    response = requester.Put(this.Address, this.Body, this.MediaType, this.AuthenticationRequired, this.SessionKey);
                    break;
                case RequestType.Get:
                    response = requester.Get(this.Address, this.MediaType, this.AuthenticationRequired, this.SessionKey);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.ResponseCode = response.StatusCode.ToString();
            this.ResponseBody = response.Content.ReadAsStringAsync().Result;
        }

        public override string ToString()
        {
            string result = string.Format(
                 @"<div class='displayItem'>
                    <header>
                        <h1 class='item-title'>{0}</h1>
                        <h3>{1}</h3>
                        <h3>{2}</h3>
                        <div>{3}</div>
                        <div class='comment'>{4}</div>
                    </header>
                    <h2>{5}</h2>
                    <h2>{6}</h2>
                </div>",
                 this.Type.ToString() + " - " + this.Address,
                 "Authentication : " + (this.AuthenticationRequired? "<br/>" + this.SessionKey : this.AuthenticationRequired.ToString()),
                 "Content-Type : " + this.MediaType,
                 "Body: <br/>" + this.Body,
                 this.Comments,
                 "Response Code : " + this.ResponseCode,
                 "Response Body : <br/>" + this.ResponseBody);

            return result;
        }

    }
}
