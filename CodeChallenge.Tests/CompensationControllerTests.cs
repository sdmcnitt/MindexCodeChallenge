
using System;
using System.Net;
using System.Net.Http;
using System.Text;

using CodeChallenge.Models;

using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeCodeChallenge.Tests.Integration
{
    [TestClass]
    public class CompensationControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize]
        // Attribute ClassInitialize requires this signature
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer();
            _httpClient = _testServer.NewClient();
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }

        [TestMethod]
        public void AddCompensation_ThenGetCompensation_Returns_CreatedAndOk()
        {
            // Arrange
            var employeeId = "c0c2293d-16bd-4603-8e08-638a9d18b22c"; //george
            var newCompensation = new AddCompensationRequest()
            {
                employeeId = employeeId,
                salary = 5000000.00m,
                effectiveDate = DateTime.UtcNow
            };
            var requestContent = new JsonSerialization().ToJson(newCompensation);

            // Execute POST
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var postResponse = postRequestTask.Result;

            // Assert POST
            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);

            // Execute GET
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var getResponse = getRequestTask.Result;

            // Assert GET
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
            var compensation = getResponse.DeserializeContent<Compensation>();
            Assert.IsNotNull(compensation);
            Assert.AreEqual(newCompensation.employeeId, compensation.employee.EmployeeId);
            Assert.AreEqual(newCompensation.salary, compensation.salary);
            Assert.AreEqual(newCompensation.effectiveDate, compensation.effectiveDate);
        }

        //TASK2: endpoint /api/compensation
        //test happy path add request
        [TestMethod]
        public void AddCompensation_Returns_Created()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f"; //john lennon
            var newCompensation = new AddCompensationRequest()
            {
                employeeId = employeeId,
                salary = 100000.00m,
                effectiveDate = DateTime.UtcNow
            };
            var requestContent = new JsonSerialization().ToJson(newCompensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        //TASK2: endpoint /api/compensation/id
        //gets the expected employee
        [TestMethod]
        public void GetCompensationById_Check_Employee_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f"; //john lennon
            var expectedFirstName = "John";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var compensation = response.DeserializeContent<Compensation>();
            Assert.IsNotNull(compensation);
            Assert.IsNotNull(compensation.employee, "The employee should be returned or NotFound response");
            Assert.AreEqual(expectedFirstName, compensation.employee.FirstName);
        }

        //TASK2: endpoint /api/compensation/id
        //add the endpoint test then create the endpoint to pass
        [TestMethod]
        public void GetBogusCompensationById_Returns_404NotFound()
        {
            // Arrange
            var employeeId = Guid.NewGuid().ToString();

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        //TASK2: endpoint /api/compensation/id
        //add the endpoint test then create the endpoint to pass
        [TestMethod]
        public void GetCompensationById_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f"; //john lennon

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
