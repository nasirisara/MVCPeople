using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models;
using MVCPeople.Models.Repos;
using MVCPeople.Models.Services;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        private readonly ICityService _cityService;
        public PeopleController(IPeopleService peopleService, ICityService cityService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
        }
        

        public IActionResult People()
        {
            return View(_peopleService.GetAll());
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        {
            CreatePersonViewModel model = new CreatePersonViewModel();
            model.Cities = _cityService.GetAll();
            return View(model);

        }
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Create(createPerson);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name,Phonenumber & City", exception.Message);
                    return View(createPerson);
                }

                return RedirectToAction(nameof(People));
            }
            return View(createPerson);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }

            return View(person);
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }
            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                CityId = person.Id
            };
            editPerson.Cities = _cityService.GetAll();
            ViewBag.Id = id;

            return View(editPerson);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, CreatePersonViewModel editPerson)
        {

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }

            editPerson.Cities = _cityService.GetAll();
            ViewBag.Id = id;

            return View(editPerson);
        }

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }
            else
            {
                _peopleService.Remove(id);

            }

            return View();
        }
        [HttpPost]
        public IActionResult People(string search)
        {
            if (search != null)
            {
                return View(_peopleService.Search(search));
            }
            return RedirectToAction(nameof(People));
        }
        public IActionResult PersonLanguage(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }
            return View(_peopleService.PersonLanguage(person));
        }

        public IActionResult AddLanguage(int personId, int languageId)
        {
            Person person = _peopleService.FindById(personId);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }
            _peopleService.AddLanguage(person, languageId);
            return RedirectToAction(nameof(PersonLanguage), new { id = person.Id });
        }

        public IActionResult RemoveLanguage(int personId, int languageId)
        {
            Person person = _peopleService.FindById(personId);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }
            _peopleService.RemoveLanguage(person, languageId);
            return RedirectToAction(nameof(PersonLanguage), new { id = person.Id });
        }

        public IActionResult PartialViewPeople()
        {
            return PartialView("_PeopleList", _peopleService.GetAll());
        }
        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                return PartialView("_PersonDetails", person);
            }
            return NotFound();
        }
        public IActionResult AjaxDelete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                _peopleService.Remove(id);
                return PartialView("_PeopleList", _peopleService.GetAll());
            }
            return NotFound();
        }

    }
}
