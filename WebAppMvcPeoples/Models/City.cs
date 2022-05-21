using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }// Key

        public City()//Empty constructor
        { }

        public City(string cityName) { CityName = cityName; }
        [Required]
        [MaxLength(80)]
        public string CityName { get; set; }
        public List<Person> People { get; set; }//Navigation Property

        [ForeignKey("Country")]
        public int CountryId { get; set; }// PeopleDbContext ForeignKey
        public Country Country { get; set; }//Navigation Property


    }
}
