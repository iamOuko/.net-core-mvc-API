using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> opt) : base(opt)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
