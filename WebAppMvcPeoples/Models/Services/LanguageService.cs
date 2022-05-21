using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models.Repos;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Models.Services
{
    public class LanguageService : ILanguageService
    {
        private ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Create(CreateLanguageViewModel createLanguage)
        {
            if (string.IsNullOrWhiteSpace(createLanguage.LanguageName))
            {
                throw new ArgumentException("Language Name may not consist of backspace(s)/whitespace(s)");
            }
            Language language = new Language() { LanguageName = createLanguage.LanguageName };
            _languageRepo.Create(language);
            return language;
        }

        public List<Language> GetAll()
        {
            return _languageRepo.GetAll();
        }

        public List<Language> FindBy(string search)
        {
            List<Language> searchLanguage = _languageRepo.GetAll();
            //
            foreach (Language item in _languageRepo.GetAll())
            {
                if (item.LanguageName.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchLanguage.Add(item);
                }
            }
            //searchPerson = searchPerson.Where(p => p.Name.ToUpper().Contains(search.ToUpper()) || p.City.Contains(search.ToUpper())).ToList();
            if (searchLanguage.Count == 0)
            {
                throw new ArgumentException("Could not find what you where looking for");
            }
            return searchLanguage;
        }

        public Language FindById(int id)
        {
            Language languageFound = _languageRepo.FindById(id);
            return languageFound;
        }
        public bool Edit(int id, CreateLanguageViewModel editLanguage)
        {
            Language orginalLanguage = FindById(id);
            if (orginalLanguage == null)
            {
                return false;
            }
            orginalLanguage.LanguageName = editLanguage.LanguageName;
            return _languageRepo.Update(orginalLanguage);
        }

        public bool Remove(int id)
        {
            Language languageToDelete = _languageRepo.FindById(id);
            bool succses = _languageRepo.Delete(languageToDelete);
            return succses;
        }
    }
}
