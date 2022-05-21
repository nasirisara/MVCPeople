using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.ViewModels
{
    public class PersonLanguageViewModel
    {
       
        public Person Person { get; set; }
        public List<Language> AllLanguages { get; set; }
        public List<Language> SpeakesLanguage { get; set; }

 
        public PersonLanguageViewModel() {
            AllLanguages = new List<Language>();
            SpeakesLanguage = new List<Language>();
        }
    }


}
