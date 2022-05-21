using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models.ViewModels;

namespace MVCPeople.Models.Repos
{// Roles we vill follow CRUD
     public interface IPeopleRepo
    {
        // C Create
      
        Person Create(Person person); //

        // R 
        List<Person> GetAll();//

        Person GetById(int id);// 


        // U Update the people list
        bool Update(Person person);// 
      

        // D Delete a person from the list
        void Delete(Person person);
    }//End of Interface
}//End of namespace
