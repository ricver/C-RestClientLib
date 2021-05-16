using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using restapiclientlib;
using System;

namespace UnitTestRestapiLib
{
    [TestClass]
    public class UnitTest1
    {

        //empty database
        [TestMethod]
        public void TestMethod1()
        {
            string endPoint = @"https://th-project.herokuapp.com/api/users";
            var client = new RestClientLib(endPoint);
            var json = client.MakeRequest();

            Assert.AreEqual("[]", json);
        }

        static string _id = "";
        //post entry into database
        [TestMethod]
        public void TestMethod2()
        {
            var client = new RestClientLib();

            client.EndPoint = @"https://th-project.herokuapp.com/api/users";
            client.Method = HttpVerb.POST;

            Jsonuser JU = new Jsonuser();
            JU.first_name = "Tom";
            JU.last_name = "Dick";
            JU.email = "tomdick@gmail.com";
            JU.phone = "05612345678";

            client.PostData = JsonConvert.SerializeObject(JU);
            var json = client.MakeRequest();

            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            _id = jsonObj._id.ToString();

            Assert.AreNotEqual("", _id);
        }

        //read value on database
        [TestMethod]
        public void TestMethod3()
        {
            string endPoint = @"https://th-project.herokuapp.com/api/users/" + _id;
            var client = new RestClientLib(endPoint);
            client.Method = HttpVerb.GET;
            var json = client.MakeRequest();

            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            string id = jsonObj._id.ToString();

            Assert.AreEqual(_id, id);
        }

        //delete entry on database
        [TestMethod]
        public void TestMethod4()
        {
            string endPoint = @"https://th-project.herokuapp.com/api/users/" + _id;
            var client = new RestClientLib(endPoint);
            client.Method = HttpVerb.DELETE;
            var json = client.MakeRequest();

            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            string msg = jsonObj.message.ToString();

            Assert.AreEqual(msg, "user deleted successfully!");
        }
    }
}
