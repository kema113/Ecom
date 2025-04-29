using Ecom.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Actor_Movie> Actor_Movie { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }


    }
}
