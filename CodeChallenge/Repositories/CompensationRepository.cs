using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly ILogger<ICompensationRepository> _logger;
        private readonly EmployeeContext _employeeContext;

        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext compensationContext)
        {
            _logger = logger;
            _employeeContext = compensationContext;
        }

        public Compensation Add(Compensation compensation)
        {
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetByEmployeeId(string id)
        {
            var compensation = _employeeContext.Compensations
                .SingleOrDefault(c => c.EmployeeId == id);
            return compensation;
        }
    }
}
