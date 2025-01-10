using CodeChallenge.Models;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetByEmployeeId(string id);
        Compensation Add(Compensation compensation);
    }
}
