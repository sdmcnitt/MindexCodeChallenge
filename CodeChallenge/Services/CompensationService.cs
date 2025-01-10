using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ILogger<CompensationService> _logger;
        private readonly ICompensationRepository _compensationRepo;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepo)
        {
            _logger = logger;
            _compensationRepo = compensationRepo;
        }
        public Compensation Create(Compensation compensation)
        {
            throw new System.NotImplementedException();
        }

        public Compensation GetByEmployeeId(string id)
        {
            var compensation = _compensationRepo.GetByEmployeeId(id);
            return compensation;
        }
    }
}
