using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HealthCatalystPeopleSearch.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int Age { get; set; }
        public string Interests { get; set; }
        public byte[] Photo { get; set; }
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
