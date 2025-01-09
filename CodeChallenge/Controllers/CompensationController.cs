using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;

        public CompensationController(ILogger<CompensationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetCompensation(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            object compensation = "null";

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }

    }
}
