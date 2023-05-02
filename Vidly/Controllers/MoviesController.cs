using Microsoft.AspNetCore.Mvc;
using Vidly.Infrastructure;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public MoviesController(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllAsync();
            return View("Movies", movies);
        }

        public async Task<ViewResult> New()
        {
            var genres = await _genreRepository.GetAllAsync();
            var viewModel = new MovieFormViewModel { Genres = genres };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(MovieFormViewModel viewModel)
        {
            var movie = VidlyAutoMapper.Mapper.Map<Movie>(viewModel);

            if (movie.Id == 0)
                await _movieRepository.AddAsync(movie);
            else
                await _movieRepository.UpdateAsync(movie);

            return RedirectToAction("Index", "Movies");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieRepository.GetAsync(id);

            if (movie == null) return NotFound();

            var viewModel = VidlyAutoMapper.Mapper.Map<MovieFormViewModel>(movie);
            viewModel.Genres = await _genreRepository.GetAllAsync();

            return View("MovieForm", viewModel);
        }

        [Route("Movies/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _movieRepository.GetAsync(id);

            return View("Details", customer);
        }
    }
}
