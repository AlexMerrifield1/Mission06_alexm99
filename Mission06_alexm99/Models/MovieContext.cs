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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryType = "Action" },
                new Category { CategoryID = 2, CategoryType = "Comedy" },
                new Category { CategoryID = 3, CategoryType = "Adventure" },
                new Category { CategoryID = 4, CategoryType = "Mystery" },
                new Category { CategoryID = 5, CategoryType = "Crime" }
            );

            mb.Entity<Movies>().HasData(

                new Movies
                {
                    MovieID = 1,
                    CategoryID = 2,
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
                    CategoryID = 5,
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
                    CategoryID = 1,
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

        
