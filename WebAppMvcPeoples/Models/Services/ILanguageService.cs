using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Models.Services
{
    public interface ILanguageService
    {
        Language Create(CreateLanguageViewModel createLanguage);
        List<Language> GetAll();
        List<Language> FindBy(string search);
        Language FindById(int id);
        bool Edit(int id, CreateLanguageViewModel editLanguage);
        bool Remove(int id);
    }
}
