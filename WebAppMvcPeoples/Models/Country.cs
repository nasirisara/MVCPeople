using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models
{
    public class Country
    { 

        [Key]
        public int Id { get; set; }// Needs to be set in Cityclass 
        public List<City> Cities { get; set; }//Navigation Property
        public string CountryName { get; set; }
        public Country(string countryName) { CountryName = countryName; }
        public Country()// Empty constructor
        { }

    }
}
