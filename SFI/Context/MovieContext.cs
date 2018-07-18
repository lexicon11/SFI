using System.Data.Entity;
using SFI.Models;

namespace SFI.Context
{
    public class MovieContext: DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public MovieContext() : base("name=DefaultConnection")
        {
        }
    }
}