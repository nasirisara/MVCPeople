using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.Repos
{
    public interface ICityRepo
    {
        City Create(City city);
        List<City> GetAll();
        City FindById(int id);

        bool Update(City city);
        bool Delete(City city);
    }

}
