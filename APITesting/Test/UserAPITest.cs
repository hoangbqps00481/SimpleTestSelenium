using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APITesting.Model;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using TestFrameworkCore.Helper;

namespace APITesting.Test
{
    [TestClass]
    public class UserAPITest
    {
        private RestClient client;
        [TestInitialize]

        public void TestInitialize() {
            var url = ConfigurationHelper.GetConfig<string>("url");

            client = new RestClient(url);
        }
        [TestMethod("TC05: Get List User")]
        public void VerifyGetListUser() {

           
            var randomPage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomPage}", Method.Get);
            RestResponse response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            GetUserModel model = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            model.page.Should().Be(randomPage);
           
        }

        [TestMethod("TC05: Create a new user")]
        public void VerifyCreateNewUser()
        {

            var request = new RestRequest("/api/users", Method.Post);
            request.AddHeader("Content-Type","application/json");

            var requestModel = new CreateUserRequestModel()
            {
                Name = "Vinh" + DateTime.Now.ToString(),
                Job = "Automation Test"
            };

            request.AddJsonBody(requestModel);

            RestResponse response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Assertion

            CreateUserResponseModel responseModel = JsonConvert.DeserializeObject<CreateUserResponseModel>(response.Content);
            responseModel.Name.Should().Be(requestModel.Name);
            responseModel.Job.Should().Be(requestModel.Job);
        }
    }
}
