using HealthCatalystPeopleSearch.Models;
using System.Collections.Generic;

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
