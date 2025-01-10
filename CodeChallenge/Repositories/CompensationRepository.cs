using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly ILogger<ICompensationRepository> _logger;
        private readonly IEmployeeService _employeeService;

        public CompensationRepository(ILogger<ICompensationRepository> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }
        public Compensation Add(Compensation compensation)
        {
            throw new System.NotImplementedException();
        }

        public Compensation GetByEmployeeId(string id)
        {
            var employee = _employeeService.GetById(id);
            var compensation = new Compensation() { employee = employee };
            return compensation;
        }
    }
}
