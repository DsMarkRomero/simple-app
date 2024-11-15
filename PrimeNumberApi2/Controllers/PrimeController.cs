using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeNumberApi2.Data;
using PrimeNumberApi2.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumberApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        private readonly PrimeNumberContext _context;

        public PrimeController(PrimeNumberContext context)
        {
            _context = context;
        }

        // Método para verificar si un número es primo
        [HttpGet("isprime/{number}")]
        public async Task<IActionResult> IsPrime(int number)
        {
            bool isPrime = CheckIfPrime(number);

            var primeCheck = new PrimeCheck
            {
                Number = number,
                IsPrime = isPrime,
                CheckedAt = DateTime.UtcNow
            };

            _context.PrimeChecks.Add(primeCheck);
            await _context.SaveChangesAsync();

            return Ok(new { Number = number, IsPrime = isPrime });
        }

        // Método para devolver la versión de la API
        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            return Ok(new { Version = "1.0" });
        }

        // Función privada para verificar si un número es primo
        private bool CheckIfPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }
            return true;
        }
    }
}
