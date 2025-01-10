using System;

namespace CodeChallenge.Models
{
    public class AddCompensationRequest
    {
        public string employeeId { get; set; }
        public decimal salary { get; set; } = 0.00m;
        public DateTime effectiveDate { get; set; } = DateTime.UtcNow;
    }
}
