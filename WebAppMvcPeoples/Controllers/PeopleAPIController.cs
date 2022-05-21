using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models;
using MVCPeople.Models.Services;
using MVCPeople.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCPeople.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        
        private readonly IPeopleService _peopleService;
        public PeopleAPIController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        // GET: api/<PeopleAPIController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            
            IEnumerable<Person> list = _peopleService.GetAll();

            foreach (var item in list)
            {
                item.City.People = null;
                item.City.Country.Cities = null;
            }

            return list;
        }

        // GET api/<PeopleAPIController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person person = _peopleService.FindById(id);
            person.City.People = null;
            person.City.Country.Cities = null;
            foreach (var item in person.PersonLanguages)
            {
                item.Person.PersonLanguages = null;
                if (item.Language != null)
                {
                    item.Language.PersonLanguages = null;
                }
            }
            return person;
            //return _peopleService.FindById(id);

        }

        // POST api/<PeopleAPIController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] CreatePersonViewModel createPerson)
        {
            Person person =_peopleService.Create(createPerson);
            if (person != null)
            {
                Response.StatusCode = 201;//Created
            }
            else
            {
                Response.StatusCode = 400;//Bad request
            }
        }

        // PUT api/<PeopleAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreatePersonViewModel editPerson)
        {
            _peopleService.Edit(id, editPerson);
        }

        // DELETE api/<PeopleAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _peopleService.Remove(id);
        }
    }
}
