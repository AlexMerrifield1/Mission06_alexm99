using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_alexm99.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movies>().HasData(

                new Movies
                {
                    MovieID = 1,
                    Category = "Comedy,Adventure",
                    Title = "Monty Python and the Holy Grail",
                    Year = 1975,
                    Director = "Terry Gilliam, Terry Jones",
                    Rating = "PG",
                    Edited = false,
                    Lent_To = "",
                    Notes = ""
                },
                new Movies
                {
                    MovieID = 2,
                    Category = "Action,Crime,Music",
                    Title = "Baby Driver",
                    Year = 2017,
                    Director = "Edgar Wright",
                    Rating = "R",
                    Edited = false,
                    Lent_To = "",
                    Notes = ""
                },
                new Movies
                {
                    MovieID = 3,
                    Category = "Action, Thriller",
                    Title = "John Wick",
                    Year = 2014,
                    Director = "Chad Stahelski",
                    Rating = "R",
                    Edited = false,
                    Lent_To = "",
                    Notes = ""
                }
            );
        }
    }
}

        
