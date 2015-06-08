using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceRequester
{
    class RequestPlanStrategy
    {
        public RequestPlanStrategy(string baseUrl) 
        {
            this.baseUrl = baseUrl;
        }

        private readonly string baseUrl;

        internal const string VALID_PASSWORD = "AAaa_123456";

        internal void Run(List<RequestTemplate> requests)
        {

            requests.Add(GetUserRegisterRequest("TestUser@abc.bg"));
            requests.Add(GetUserLoginRequest("TestUser@abc.bg"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games", false));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games?page=0", false));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games?page=1", false));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games?page=9999", false, "application/json", "", 1, "// This page number is way too big"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games?page=0", true));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games?page=1", true));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games?page=9999", true, "application/json", "", 1, "// This page number is way too big"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games/1", true, "application/json", "", 1, "// The game has not been created yet"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games/99999", true, "application/json", "", 1, "// This id number is way too big"));

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games", true, "application/json",
            @"{
	            'name': 'Test hame by dummy user 1',
	            'number': '4235'
            }", 1, "// the first user makes a game"));

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1", true, "application/json",
            @"{
	            'name': 'Test hame by dummy user 1',
	            'number': '4235'
            }", 1, "// Let me explain this. In my own exam, I made the misstake to route the game creation to this route, instead of the right one.\n// The misstake consist exactly of 5 symbols ('/{id}'), and without them everything works just fine.\n // This is how I used this program for personal gain. \n\n // Normally this request should be invalid"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games", false, "application/json", "", 1, "//The game should be visible without authentication now"));

            requests.Add(new RequestTemplate(RequestType.Put, this.baseUrl + "/api/games/1", true, "application/json", "{ number : '1345' }", 2, "// the second user joins the game"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games", false, "application/json", "", 1, "//The game should NOT be visible without authentication now"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games/1", true, "application/json", "", 1, "// Lets see the created game without any guesses"));

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 1, "// this number is allright"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 2, "// this number is allright"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 1, "// this number is allright"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 2, "// this number is allright"));

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 2, "// this number is allright but it shouldn't be this players turn"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 3, "// this number is allright but the user is not part of the game"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1111' }", 1, "// this number is not allright"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : 'pesho' }", 2, "// this number is pesho"));

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1345' }", 1, "// Player 1 makes the right guess"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/1/guess", true, "application/json", "{ number : '1234' }", 2, "// Player 2 makes the right guess, but the game should be over"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/games/1", true, "application/json", "", 1, "// Lets see the created game with some guesses"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/scores", false, "application/json"));

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/notifications/next", true, "application/json", "", 1, "// player joins"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/notifications", true, "application/json", "", 1));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/api/notifications/next", true, "application/json", "", 1, "//There shouldn't be any undread notifications, should there?"));

            // --------------------------------------------------------------------------

            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/services/users.svc", false, "application/json", "", 1, "// THIS IS A <strong>WCF</strong> TEST. <br/>// RUN THE APPLICATION AGAIN AND INPUT THE ADDRES OF THE <strong>WCF SERVER</strong> <br/>// THIS <strong>WILL NOT WORK</strong> OTHERWISE"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/services/users.svc?page=0", false, "application/json", "", 1, "// THIS IS A <strong>WCF</strong> TEST. <br/>// RUN THE APPLICATION AGAIN AND INPUT THE ADDRES OF THE <strong>WCF SERVER</strong> <br/>// THIS <strong>WILL NOT WORK</strong> OTHERWISE"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/services/users.svc?page=999", false, "application/json", "", 1, "// THIS IS A <strong>WCF</strong> TEST. <br/>// RUN THE APPLICATION AGAIN AND INPUT THE ADDRES OF THE <strong>WCF SERVER</strong> <br/>// THIS <strong>WILL NOT WORK</strong> OTHERWISE"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/services/users.svc/1", false, "application/json", "", 1, "// THIS IS A <strong>WCF</strong> TEST. <br/>// RUN THE APPLICATION AGAIN AND INPUT THE ADDRES OF THE <strong>WCF SERVER</strong> <br/>// THIS <strong>WILL NOT WORK</strong> OTHERWISE"));
            requests.Add(new RequestTemplate(RequestType.Get, this.baseUrl + "/services/users.svc/9999", false, "application/json", "", 1, "// THIS IS A <strong>WCF</strong> TEST. <br/>// RUN THE APPLICATION AGAIN AND INPUT THE ADDRES OF THE <strong>WCF SERVER</strong> <br/>// THIS <strong>WILL NOT WORK</strong> OTHERWISE"));

            ////

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games", true, "application/json",
           @"{
	            
	            'number': '4235'
            }", 1, "// HQC missing game name"));

            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games", true, "application/json",
           @"{
	            'name': 'Test hame by dummy user 1'
            }", 1, "// HQC missing game number"));

            requests.Add(new RequestTemplate(RequestType.Put, this.baseUrl + "/api/games/9999", true, "application/json", "{ number : '1345' }", 2, "// HQC PUT api/games/id bad ID"));
            requests.Add(new RequestTemplate(RequestType.Put, this.baseUrl + "/api/games/2", true, "application/json", "{  }", 2, "// HQC PUT api/games/id bad ID"));
            requests.Add(new RequestTemplate(RequestType.Post, this.baseUrl + "/api/games/9999/guess", true, "application/json", "{ number : '1234' }", 1, "// HQC PUT api/games/id/guess bad ID"));

        }

        private RequestTemplate GetUserLoginRequest(string email)
        {
            return new RequestTemplate(
                RequestType.Post,
                 this.baseUrl + "/token",
                false, "application/x-www-form-urlencoded",
                "Username=" + email + "&Password=" + VALID_PASSWORD + "&grant_type=password"
                );
        }

        private RequestTemplate GetUserRegisterRequest(string email)
        {
            return new RequestTemplate(
                RequestType.Post,
                 this.baseUrl + "/api/account/register",
                false,
                "application/x-www-form-urlencoded",
                "Email=" + email + "&Password=" + VALID_PASSWORD + "&ConfirmPassword=" + VALID_PASSWORD
                );
        }
    }
}
