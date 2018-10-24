using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Movies.Models
{
    public class MVC_MoviesContext : DbContext
    {
        public MVC_MoviesContext (DbContextOptions<MVC_MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Movies.Models.Movies1> Movies1 { get; set; }
    }
}
