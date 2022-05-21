﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models;
using MVCPeople.Models.Services;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Controllers
{
    public class CityController : Controller
    {

        private  ICityService _cityService;
        private  ICountryService _countryService;
        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }
   
        public IActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();
            model.Countries = _countryService.All();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Create(createCity);
                return RedirectToAction(nameof(Index));
            }
            return View(createCity);
        }
 

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            City city = _cityService.FindById(Id);
            if (city == null)
            {
               
                return RedirectToAction(nameof(Index));
            }
            CreateCityViewModel createCity = new CreateCityViewModel();
            createCity.CityName = city.CityName;
            ViewBag.Id = city.Id;
            return View(createCity);

        }
        [HttpPost]
        public IActionResult Edit(int id, CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                if (_cityService.Edit(id,createCity))
                {
                    return RedirectToAction(nameof(Index));
                }
                //ModelState.AddModelError("Unable to save or save your changes");
            }
            ViewBag.Id = id;
            return View(createCity);

        }
        public IActionResult Delete(int id)
        {
            _cityService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
