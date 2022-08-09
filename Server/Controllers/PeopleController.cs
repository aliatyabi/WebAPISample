using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace WebAPISample.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet(Name = nameof(GetPeopleTransactions))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<PersonTransactionsViewModel>>> GetPeopleTransactions()
        {
            var peopleTransactions = await _personService.GetPeopleTransactions();

            if (!peopleTransactions.Any())
            {
                return NotFound();
            }

            return Ok(peopleTransactions);
        }

        [HttpPost(Name = nameof(AddPeople))]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddPeople(IEnumerable<Person> people)
        {
            await _personService.AddPeopleAsync(people);

            return Ok();
        }
    }
}
