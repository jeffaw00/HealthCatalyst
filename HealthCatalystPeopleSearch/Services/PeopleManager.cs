using HealthCatalystPeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HealthCatalystPeopleSearch.Services
{
    public class PeopleManager : IPeopleManager
    {
        public Home GetHome()
        {
            Home home = new Home();

            home.persons = GetAllPeople();

            return home;
        }

        public Persons GetAllPeople()
        {
            Persons people = new Persons();

            using (var context = new PersonContext())
            {
                var query = from b in context.Persons
                            select b;
                people.persons = query.ToList();
            }

            return people;
        }

        public List<string> GetNames()
        {
            List<string> names = new List<string>();

            using (var context = new PersonContext())
            {
                var query = from b in context.Persons
                            select b.FirstName + " " + b.LastName;
                names = query.ToList();
            }

            return names;
        }

        public Person GetPerson(string name)
        {
            Person person = new Person();

            try
            {
                if (name != null)
                {
                    using (var context = new PersonContext())
                    {
                        var query = from b in context.Persons
                                    where b.FirstName + " " + b.LastName == name
                                    select b;
                        person = (Person)query.First();
                    }
                }
            }
            catch(Exception ex)
            {
                // nothing to do here for now, normally would log to db
            }

            return person;
        }

        public byte[] GetPhoto(int PersonId)
        {
            if (PersonId > 0)
            {
                using (var context = new PersonContext())
                {
                    return context.Persons.Find(PersonId).Photo;
                }
            }
            else
                return null;
        }

        public Person AddPerson(Person person)
        {
            using (var context = new PersonContext())
            {
                context.Persons.Add(person);
                context.SaveChanges();
            }

            return person;
        }

        public void DeletePerson(int PersonId)
        {
            using (var context = new PersonContext())
            {
                Person person = context.Persons.Find(PersonId);
                if(person != null)
                {
                    context.Persons.Remove(person);
                    context.SaveChanges();
                }
            }
        }

        public void Reseed()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonContext"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spReseed", conn))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
