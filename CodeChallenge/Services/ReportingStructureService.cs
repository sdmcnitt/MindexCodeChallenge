using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly ILogger<ReportingStructureService> _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureService(ILogger<ReportingStructureService> logger,
            IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public ReportingStructure GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                var employee = _employeeService.GetById(id);
                if(employee == null) return null;

                return new ReportingStructure() { employee = employee, numberOfReports = CalcNumberOfReports(employee) };
            }

            return null;
        }

        private int CalcNumberOfReports(Employee employee)
        {
            var totalNumberOfReports = 0;
            var directReports = employee.DirectReports;

            if (directReports == null) return totalNumberOfReports;
            
            foreach (var directReport in directReports)
            {
                totalNumberOfReports++;
                totalNumberOfReports += CalcNumberOfReports(directReport);
            }

            return totalNumberOfReports;
        }
    }
}
