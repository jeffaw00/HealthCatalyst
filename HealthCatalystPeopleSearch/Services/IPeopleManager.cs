using HealthCatalystPeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCatalystPeopleSearch.Services
{
    public interface IPeopleManager
    {
        Persons GetAllPeople();

        List<string> GetNames();

        Person GetPerson(string name);

        Person AddPerson(Person person);

        void DeletePerson(int PersonId);

        Home GetHome();

        void Reseed();

        byte[] GetPhoto(int PersonId);
    }
}
