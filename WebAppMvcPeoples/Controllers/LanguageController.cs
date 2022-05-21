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
    public class LanguageController : Controller
    {

        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;

        }

        public IActionResult Index()
        {
            return View(_languageService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Create(createLanguage);

                return RedirectToAction(nameof(Index));
            }
            return View(createLanguage);
        }

        public IActionResult Details(int Id)
        {
            Language language = _languageService.FindById(Id);
            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Language language = _languageService.FindById(Id);
            if (language == null)
            {

                return RedirectToAction(nameof(Index));
            }
            CreateLanguageViewModel createLanguage = new CreateLanguageViewModel();
            createLanguage.LanguageName = language.LanguageName;
            ViewBag.Id = language.Id;
            return View(createLanguage);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                if (_languageService.Edit(id, createLanguage))
                {
                    return RedirectToAction(nameof(Index));
                }
                //ModelState.AddModelError("Unable to save or save your changes");
            }
            ViewBag.Id = id;
            return View(createLanguage);

        }
        public IActionResult Delete(int id)
        {
            _languageService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
