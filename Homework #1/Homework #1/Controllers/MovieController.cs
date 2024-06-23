using Homework__1.Database;
using Homework__1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework__1.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var movies = InMemoryDatabase.Movies;
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = InMemoryDatabase.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Rent(int movieId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var movie = InMemoryDatabase.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null || movie.Quantity <= 0)
            {
                return NotFound();
            }

            var rental = new Rental
            {
                Id = InMemoryDatabase.Rentals.Count + 1, // Generate new ID
                MovieId = movieId,
                UserId = userId.Value,
                RentedOn = DateTime.Now
            };

            movie.Quantity--;
            InMemoryDatabase.Rentals.Add(rental);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Return(int rentalId)
        {
            var rental = InMemoryDatabase.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental == null)
            {
                return NotFound();
            }

            var movie = InMemoryDatabase.Movies.FirstOrDefault(m => m.Id == rental.MovieId);
            if (movie == null)
            {
                return NotFound();
            }

            rental.ReturnedOn = DateTime.Now;
            movie.Quantity++;

            return RedirectToAction("MyRentals");
        }

        public IActionResult MyRentals()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var rentals = InMemoryDatabase.Rentals.Where(r => r.UserId == userId.Value && r.ReturnedOn == null).ToList();
            return View(rentals);
        }
    }
}
}
