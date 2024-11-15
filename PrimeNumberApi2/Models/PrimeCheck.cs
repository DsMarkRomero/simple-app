using System;

namespace PrimeNumberApi2.Models
{
    public class PrimeCheck
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsPrime { get; set; }
        public DateTime CheckedAt { get; set; }
    }
}
