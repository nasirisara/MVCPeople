using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models
{
    public class PersonLanguage // Join table for to many to many
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
