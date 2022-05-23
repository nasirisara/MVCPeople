using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Models.Repos
{
     public interface IPeopleRepo
    {
      
        Person Create(Person person); 

        List<Person> GetAll();

        Person GetById(int id);


        bool Update(Person person);
      

        void Delete(Person person);
    }
}
