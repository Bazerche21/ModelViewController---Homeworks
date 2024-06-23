using Homework__1.Models;
using Homework__1.Models.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;

namespace Homework__1.Database
{
    public class InMemoryDatabase
    {
        public static List<User> Users { get; private set; }
        public static List<Movie> Movies { get; private set; }
        public static List<Cast> Casts { get; private set; }
        public static List<Rental> Rentals { get; private set; }

        static InMemoryDatabase()
        {
            LoadUsers();
            LoadMovies();
            LoadCasts();
            LoadRentals();
        }

        private static void LoadUsers()
        {
            Users = new List<User>
        {
            new User { Id = 1, FullName = "John Doe", Age = 30, CardNumber = "985436", CreatedOn = DateTime.Now, IsSubscriptionExpired = false, SubscriptionType = SubscriptionType.Monthly },
            new User { Id = 2, FullName = "Jane Smith", Age = 25, CardNumber = "173564", CreatedOn = DateTime.Now, IsSubscriptionExpired = false, SubscriptionType = SubscriptionType.Yearly }
        };
        }

        private static void LoadMovies()
        {
            Movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Genre = Genre.SciFi, Language = Language.English, IsAvailable = true, ReleaseDate = new DateTime(2010, 7, 16), Length = new TimeSpan(2, 28, 0), AgeRestriction = 13, Quantity = 5 },
            new Movie { Id = 2, Title = "The Godfather", Genre = Genre.Drama, Language = Language.English, IsAvailable = true, ReleaseDate = new DateTime(1972, 3, 24), Length = new TimeSpan(2, 55, 0), AgeRestriction = 17, Quantity = 3 },
            new Movie { Id = 3, Title = "Parasite", Genre = Genre.Drama, Language = Language.Korean, IsAvailable = true, ReleaseDate = new DateTime(2019, 5, 30), Length = new TimeSpan(2, 12, 0), AgeRestriction = 16, Quantity = 4 }
        };
        }

        private static void LoadCasts()
        {
            Casts = new List<Cast>
        {
            new Cast { Id = 1, MovieId = 1, Name = "Leonardo DiCaprio", Part = Part.Actor },
            new Cast { Id = 2, MovieId = 1, Name = "Christopher Nolan", Part = Part.Director },
            new Cast { Id = 3, MovieId = 2, Name = "Marlon Brando", Part = Part.Actor  },
            new Cast { Id = 4, MovieId = 2, Name = "Francis Ford Coppola", Part = Part.Director },
            new Cast { Id = 5, MovieId = 3, Name = "Song Kang-ho", Part = Part.Actor },
            new Cast { Id = 6, MovieId = 3, Name = "Bong Joon-ho", Part = Part.Director }
        };
        }

        private static void LoadRentals()
        {
            Rentals = new List<Rental>
        {
            new Rental { Id = 1, MovieId = 1, UserId = 1, RentedOn = DateTime.Now.AddDays(-2), ReturnedOn = null },
            new Rental { Id = 2, MovieId = 2, UserId = 2, RentedOn = DateTime.Now, ReturnedOn = null }
        };
        }
    }
}

