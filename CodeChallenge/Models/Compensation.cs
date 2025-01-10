using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public Employee employee { get; set; }
        public decimal salary { get; set; } = 0.00m;
        public DateTime effectiveDate { get; set; } = DateTime.UtcNow;

        //note DateOnly serialization not supported until .net6
        //instead of createing a converter just assume right now that the time portion will just be ignored
        //or can change to dateonly on the way out
        //https://stackoverflow.com/questions/74246482/system-notsupportedexception-serialization-and-deserialization-of-system-dateo
        //public DateOnly effectiveDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    }
}
