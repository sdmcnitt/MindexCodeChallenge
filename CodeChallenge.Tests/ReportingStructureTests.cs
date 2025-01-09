
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
    public class ReportingControllerTests
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

        //TASK1: endpoint /api/reportingstructure
        //employee with no direct reports returns 200 with NumberOfReports and zero numberOfReports
        [TestMethod]
        public void GetReportingStructureById_EmpWithExpectedDirectReports_Returns_OK()
        {
            // Arrange
            var employee = "16a596ae-edd3-4847-99fe-c4518e82c86f"; //john
            var expectedFirstName = "John";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingstructure/{employee}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var reportingStructure = response.DeserializeContent<ReportingStructure>();
            Assert.IsNotNull(reportingStructure);
            Assert.AreEqual(expectedFirstName, reportingStructure.employee.FirstName);
            Assert.AreEqual(4, reportingStructure.numberOfReports);
        }

        //TASK1: endpoint /api/reportingstructure
        //employee with no direct reports returns 200 with NumberOfReports and zero numberOfReports
        [TestMethod]
        public void GetReportingStructureById_EmpWithNoDirectReports_Returns_OK()
        {
            // Arrange
            var employee = "c0c2293d-16bd-4603-8e08-638a9d18b22c"; //george
            var expectedFirstName = "George";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingstructure/{employee}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var reportingStructure = response.DeserializeContent<ReportingStructure>();
            Assert.IsNotNull(reportingStructure);
            Assert.AreEqual(expectedFirstName, reportingStructure.employee.FirstName);
            Assert.AreEqual(0, reportingStructure.numberOfReports);
        }

        //TASK1: endpoint /api/reportingstructure
        //bad id returns not found
        [TestMethod]
        public void GetBogusReportingStructureById_Returns_404NotFound()
        {
            // Arrange
            var badEmployeeNumber = Guid.NewGuid().ToString();

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingstructure/{badEmployeeNumber}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        //TASK1: endpoint /api/reportingstructure
        //add the endpoint test then create the endpoint to pass
        [TestMethod]
        public void GetReportingStructureById_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f"; //john lennon

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingstructure/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
