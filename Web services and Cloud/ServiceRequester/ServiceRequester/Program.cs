using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequester
{
    class Program
    {
        static List<RequestTemplate> requests = new List<RequestTemplate>();
        private static string baseUrl;

        static void Main(string[] args)
        {
            Console.Write("Input base URL of server: ");
            baseUrl = Console.ReadLine();

            new RequestPlanStrategy(baseUrl).Run(requests);

            RegisterDummyUsers();
            SendRequests();
            WriteToFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Exam-Web&Clauld-2014_by-ServiceRequester.html");

            Console.WriteLine("\n\n\n" + "Check your desktop for the generated HTML file.\nPress [Enter] to exit the program.");
            Console.ReadLine();
        }

        private static void RegisterDummyUsers()
        {
            string[] usernames = {
                                     "FirstUser@abv.bg", 
                                     "SecondUser@abv.bg", 
                                     "ThirdUser@abv.bg", 
                                     "FourthUser@abv.bg"
                                 };
            HttpRequester requester = new HttpRequester();
            foreach (var name in usernames)
            {
                Console.WriteLine("Attempting to register dummy user <" + name + ">\n > Please wait for a while...");
                try
                {
                    string key = requester.RegisterUserAndGetSessionKey(name, baseUrl + "/api/account/register", baseUrl + "/token");
                    RequestTemplate.SessionKeys.Add(key);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: dummy user <" + name + "> has not been registered!");
                }
            }
        }

        private static void SendRequests()
        {
            foreach (var request in requests)
            {
                Console.WriteLine("Requesting <" + request.Address + ">\n > Please wait for a while...");
                try
                {
                    request.GetResponseFromServer();
                }
                catch (Exception)
                {
                    request.ResponseCode = "<span style='color:red;'>An error occured</span>";
                    request.ResponseBody = "<span style='color:red;'>An error occured. Please look at the code for more details</span>";
                }
            }
        }

        private static void WriteToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                WriteTopOfFile(writer);
                foreach (var req in requests)
                {
                    writer.WriteLine(req.ToString());
                }
                WriteBottomOfFile(writer);
            }
        }

        private static void WriteTopOfFile(StreamWriter writer)
        {
            writer.WriteLine(@"
<!DOCTYPE HTML>
<html>
	<head>
		<title>Services test</title>
		<style>
			body > div#wrapper > div {
				word-wrap: break-word;
				width: 90%;
				min-height: 200px;
				border: 3px solid black;
				padding: 10px;
				background: rgb(245,245,245);
				margin: auto;
				margin-top: 20px;
				color: rgb(25,25,25);
			}
			body > div#wrapper > div > header {
				color: black;
				padding: 10px;
				background: white;
			}
			body > div#wrapper > div > header * {
				border-bottom: 1px solid gray;
			}
			.comment {
				color: darkgreen;
				font-size: 16px;
				font-weight: bolder;
			}
            .item-title {
				color: darkred;
                background: rgba(220,220,220, 0.1);
            }
		</style>
	</head>
	<body>
		<div id='wrapper'>");

        }

        private static void WriteBottomOfFile(StreamWriter writer)
        {
            writer.WriteLine(@"
		</div>
	</body>
</html>");

        }

    }
}
