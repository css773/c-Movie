using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void InitialData(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Marry Met Sally",
                        ReleaseDate = DateTime.Parse("1982-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghsothunters",
                        ReleaseDate = DateTime.Parse("1984-2-12"),
                        Genre = "Comedy",
                        Price = 8.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}