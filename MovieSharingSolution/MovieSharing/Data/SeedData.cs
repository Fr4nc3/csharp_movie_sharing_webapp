using MovieSharing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MovieSharing.Data
{
    public class SeedData
    {
        /// <summary>
        /// Seed default dataset
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieSharingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieSharingContext>>()))
            {
                // imperson users
                if (context.Imperson.Any() == false)
                {
                    context.Imperson.AddRange(
                       new Imperson
                       {
                           Email = "test01-fake@outlook.com",
                           Name = "Joseph test-fake",
                       },
                       );
                    context.SaveChanges();
                }
                // default categories
                if (context.Category.Any() == false)
                {
                    context.Category.AddRange(
                       new Category
                       {

                           Name = "Science Fiction",

                       },
                       new Category
                       {

                           Name = "Drama",
                       },
                       new Category
                       {

                           Name = "Adventure",
                       }
                       );
                    context.SaveChanges();
                }
                // Look for any Movies.
                if (context.Movie.Any() == false)
                {
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "Star Wars IV",
                            Category = "Science Fiction",
                            IsSharable = true,
                            OwnerEmailAddress = "francia-test@lala.com",
                            OwnerName = "francia test"
                        },
                        new Movie
                        {
                            Title = "The Matrix",
                            Category = "Science Fiction",
                            IsSharable = true,
                            OwnerEmailAddress = "francia-test@lala.com",
                            OwnerName = "francia test"
                        },
                        new Movie
                        {
                            Title = "The Social Network",
                            Category = "Drama",
                            IsSharable = true,
                            OwnerEmailAddress = "francia-test@lala.com",
                            OwnerName = "francia test"
                        },
                        new Movie
                        {
                            Title = "Star Trek First Contact",
                            Category = "Science Fiction",
                            IsSharable = true,
                            OwnerEmailAddress = "francia-test@lala.com",
                            OwnerName = "francia test"
                        },
                        new Movie
                        {
                            Title = "Captain Marvel",
                            Category = "Adventure",
                            IsSharable = false,
                            OwnerEmailAddress = "francia-test@lala.com",
                            OwnerName = "francia test"
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}
