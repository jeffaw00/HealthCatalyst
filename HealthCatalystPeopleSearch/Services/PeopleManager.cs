using HealthCatalystPeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCatalystPeopleSearch.Services
{
    public class PeopleManager : IPeopleManager
    {
        public Persons GetAllPeople()
        {
            Persons people = new Persons();

            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["PersonContext"]))
            {
                using (var context = new PersonContext())
                {
                    context.Database.Connection.Open();
                    var query = from b in context.Persons
                                select b;
                    people.persons = query.ToList();
                }
            }

            return people;
        }
    }
}
