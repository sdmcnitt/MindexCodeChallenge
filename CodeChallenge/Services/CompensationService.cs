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
        public Compensation Add(Compensation compensation)
        {
            return _compensationRepo.Add(compensation);
        }

        public Compensation GetByEmployeeId(string id)
        {
            return _compensationRepo.GetByEmployeeId(id);
        }
    }
}
