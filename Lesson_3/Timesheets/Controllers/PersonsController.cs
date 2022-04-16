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
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<ContractsController> _logger;

        private readonly IPersonService _personService;

        public PersonsController(ILogger<ContractsController> logger, IPersonService personService)
        {
            _logger = logger;

            _personService = personService;
        }

        [HttpGet]
        public List<Person> Get()
        {
            return _personService.GetPersons();
        }


        [HttpGet("{id}")]
        public List<Person> Get(int id)
        {
            return _personService.GetPerson(id);
        }

        [HttpGet("SearchPerson/{firstName}")]
        public List<Person> SearchPerson(string firstName)
        {
            return _personService.SearchPerson(firstName);
        }

        [HttpGet("PrintPersons/")]
        public List<Person> PrintPersons([FromQuery] int skip, [FromQuery] int take)
        {
            return _personService.PrintPersons(skip, take);
        }

        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _personService.AddPerson(person);
        }

        [HttpPut]
        public void Put([FromBody] Person person)
        {
            _personService.UpdatePerson(person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personService.DeletePerson(id);
        }

    }
}
