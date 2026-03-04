using Microsoft.EntityFrameworkCore;
using PersonsApp.Entites;

namespace PersonsApp.DataBase
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<PersonEntity> Persons { get; set; }
    }
}