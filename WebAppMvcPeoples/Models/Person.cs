using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPeople.Models
{// the blueprint of a Person or my person dataModel

    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Person()
        { }
        public Person(string name)
        {
            Name = name;
        }
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }//Navigation Property

    }//End of Person Class
}//End of namespace
