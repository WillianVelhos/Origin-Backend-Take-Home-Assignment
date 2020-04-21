using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RiskProfile.Domain.Enums;
using RiskProfile.Web.Message.Request;
using RiskProfile.Web.Test.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RiskProfile.Web.Test.Controllers
{
    public class RiskProfileControllerTest
    {
        [Fact]
        public async void TheResponseShouldBeOK()
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New.Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void TheResponseShouldBeBadRequestWithNegativeAge()
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddAge(-1)
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "Age"); ;

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The Age is required integer equal or greater than 0", errorMessage);
        }

        [Fact]
        public async void TheResponseShouldBeBadRequestWithNegativeDependents()
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddDependents(-1)
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "Dependents");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The Dependents is required integer equal or greater than 0", errorMessage);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(-1)]
        public async void TheResponseShouldBeBadRequestWithInvalidOwnershipStatus(int ownershipStatus)
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddHouse(new CalculateRiskProfileHouseRequest() { OwnershipStatus = (OwnershipStatus)ownershipStatus })
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "House.OwnershipStatus");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The Ownership Status is required Enum Owned = 0 and Mortgaged = 1", errorMessage);
        }

        [Fact]
        public async void TheResponseShouldBeBadRequestWithNegativeIncome()
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddIncome(-1)
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "Income");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The Income is required integer equal or greater than 0", errorMessage);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(-1)]
        public async void TheResponseShouldBeBadRequestWithInvalidMaritalStatus(int maritalStatus)
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddMaritalStatus((MaritalStatus)maritalStatus)
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "MaritalStatus");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The Marital Status is required Enum Single = 0 and Married = 1", errorMessage);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, })]
        [InlineData(new int[] { 1, 1, 1, 1 })]
        [InlineData(new int[] { 1, 1, 2 })]
        [InlineData(null)]
        public async void TheResponseShouldBeBadRequestWithInvalidRiskQuestions(ICollection<int> riskQuestions)
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddRiskQuestions(riskQuestions)
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "RiskQuestions");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The RiskQuestions is required array with 3 booleans", errorMessage);
        }

        [Theory]
        [InlineData(-1)]
        public async void TheResponseShouldBeBadRequestWithInvalidVehicle(int year)
        {
            //arrage
            var client = TestClientProvider.New.Client;
            var request = CalculateRiskProfileRequestBuilderTest.New
                                                                .AddVehicle(new CalculateRiskProfileVehicleRequest() { Year = year })
                                                                .Build();
            var requestMessage = CreateHttpRequestMessage(HttpMethod.Post, "riskprofile/calculate", request);

            //act
            var response = await client.SendAsync(requestMessage);
            var errorMessage = await GetErrorMessageReponse(response, "Vehicle.Year");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The Vehicle Year is required integer greater than 0", errorMessage);
        }

        private async Task<string> GetErrorMessageReponse(HttpResponseMessage response, string attribute)
        {
            var reponseJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ValidationProblemDetails>(reponseJson);

            return result.Errors.First(x => x.Key == attribute).Value.First();
        }

        private HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, string url, object value)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, url);

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(value),
                                                       Encoding.UTF8,
                                                       "application/json");

            return requestMessage;
        }
    }
}