using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.Service;
using Timesheets.Repository;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/dbpersons")]
    public class DbPersonsController : ControllerBase
    {
        private readonly ILogger<ContractsController> _logger;

        private readonly IDbPersonRepository _dbPersonRepository;

        public DbPersonsController(ILogger<ContractsController> logger, IDbPersonRepository dbPersonRepository)
        {
            _logger = logger;

            _dbPersonRepository = dbPersonRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            var res = await _dbPersonRepository.Get();
            return Ok(res);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Person userNew)
        {
            await _dbPersonRepository.Add(userNew);

            return NoContent();
        }
        
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Person user)
        {
            await _dbPersonRepository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _dbPersonRepository.Delete(id);
            return NoContent();
        }

    }
}