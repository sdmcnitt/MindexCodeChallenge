using CodeChallenge.Models;
using CodeChallenge.Services;
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
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCompensation(string id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetByEmployeeId(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] AddCompensationRequest addCompensation)
        {
            _logger.LogDebug($"Received compensation create request for '{addCompensation.employeeId}'");

            var compensation = _compensationService.Add(addCompensation);

            //return CreatedAtRoute("CreateCompensation", new { id = addCompensation.employeeId }, compensation);
            return CreatedAtAction(nameof(GetCompensation), new { id = addCompensation.employeeId }, compensation);
        }
    }
}
