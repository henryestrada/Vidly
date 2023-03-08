using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "Shrek"
            },

            new Movie
            {
                Id = 2,
                Name = "Wall-E"
            }
        };

        public IActionResult Index()
        {
            return View("Movies", _movies);
        }

        [Route("Movies/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var customer = _movies.Single(x => x.Id == id);

            return View("Details", customer);
        }
    }
}
