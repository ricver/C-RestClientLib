using restapiclientlib;
using System;

namespace RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //RestClientLib rcl = new RestClientLib();
            //rcl.

            //https://th-project.herokuapp.com/api/users
            string endPoint = @"https://th-project.herokuapp.com/api/users";
            var client = new RestClientLib(endPoint);
            var json = client.MakeRequest();


            Console.ReadLine();

            //var json = client.MakeRequest("?param=0");

            //var client = new RestClient(endpoint: endPoint,
            //                method: HttpVerb.POST,
            //                postData: "{'someValueToPost': 'The Value being Posted'}");

            //var client = new RestClient();
            //client.EndPoint = @"http:\\myRestService.com\api\"; ;
            //client.Method = HttpVerb.POST;
            //client.PostData = "{postData: value}";
            //var json = client.MakeRequest();
        }
    }
}
