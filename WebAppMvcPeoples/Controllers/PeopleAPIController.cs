using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models;
using MVCPeople.Models.Services;
using MVCPeople.Models.ViewModels;

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
            

        }

        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] CreatePersonViewModel createPerson)
        {
            Person person = _peopleService.Create(createPerson);
            if (person != null)
            {
                Response.StatusCode = 201;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

  
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreatePersonViewModel editPerson)
        {
            _peopleService.Edit(id, editPerson);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _peopleService.Remove(id);
        }
    }
}
