using Microsoft.AspNetCore.Mvc;
using Vidly.Repositories;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllAsync();
            return View("Movies", movies);
        }

        [Route("Movies/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _movieRepository.GetAsync(id);

            return View("Details", customer);
        }
    }
}
