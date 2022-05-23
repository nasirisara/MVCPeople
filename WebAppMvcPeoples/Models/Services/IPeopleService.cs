using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Models.Services
{
    public interface IPeopleService
    {
        Person Create(CreatePersonViewModel createPerson);
        List<Person> GetAll();
        List<Person> Search(string Search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel editPerson);
        void Remove(int id);
        PersonLanguageViewModel PersonLanguage(Person person);
        void RemoveLanguage(Person person, int languageId);
        void AddLanguage(Person person, int languageId);


    }

}
