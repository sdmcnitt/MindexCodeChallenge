using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ILogger<CompensationService> _logger;
        private readonly ICompensationRepository _compensationRepo;
        private readonly IEmployeeService _employeeService;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepo, IEmployeeService employeeService)
        {
            _logger = logger;
            _compensationRepo = compensationRepo;
            _employeeService = employeeService;
        }
        public Compensation Add(AddCompensationRequest addCompensation)
        {
            var employee = _employeeService.GetById(addCompensation.employeeId);
            if (employee == null) return null;

            var newCompensation = new Compensation() 
            { 
                effectiveDate = addCompensation.effectiveDate,
                salary = addCompensation.salary,
                employee = employee,
            };
            return _compensationRepo.Add(newCompensation);
        }

        public Compensation GetByEmployeeId(string id)
        {
            return _compensationRepo.GetByEmployeeId(id);
        }
    }
}
