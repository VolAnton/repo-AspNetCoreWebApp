using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractsController : ControllerBase
    {
        private static readonly List<Contract> ContractsRepository = new List<Contract>
        {
            new Contract{Name = "The first", Description = "The first task"},
            new Contract{Name = "The second", Description = "The second task"},
            new Contract{Name = "The third", Description = "The third task"},
        };

        private readonly ILogger<ContractsController> _logger;

        public ContractsController(ILogger<ContractsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Contract contract)
        {
            _logger.LogDebug("");
            if (contract.Name != null && contract.Description != null)
            {
                ContractsRepository.Add(new Contract { Name = contract.Name, Description = contract.Description });
            }
            return Ok();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            _logger.LogDebug("");

            return Ok(ContractsRepository);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            _logger.LogDebug("");

            int index = ContractsRepository.FindIndex(item => item.Id == id);

            if (index == -1)
            {
                return BadRequest($"Contract with id {id} is not found");
            }

            return Ok(ContractsRepository[index]);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] Contract contract, [FromRoute] int id)
        {
            _logger.LogDebug("");

            int index = ContractsRepository.FindIndex(item => item.Id == id);

            if (index == -1)
            {
                return BadRequest($"Contract with id {id} is not found");
            }

            ContractsRepository[id].Name = contract.Name;
            ContractsRepository[id].Description = contract.Description;

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogDebug("");

            int index = ContractsRepository.FindIndex(item => item.Id == id);

            if (index == -1)
            {
                return BadRequest($"Contract with id {id} is not found");
            }

            ContractsRepository.RemoveAt(index);

            return Ok();
        }
    }
}
