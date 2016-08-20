using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HealthCatalystPeopleSearch.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PicName { get; set; }
        public string PicLocation { get; set; }
        public string Interests { get; set; }
    }

    public class PersonContext : DbContext
    {
        public PersonContext()
            : base("name=PersonContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
