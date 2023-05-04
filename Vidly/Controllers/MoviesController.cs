using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.ViewModels;

namespace Vidly.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class MoviesController : Controller
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public MoviesController(IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _mapper = mapper;
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(MovieFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var newViewModel = new MovieFormViewModel(viewModel)
            {
                Genres = await _genreRepository.GetAllAsync()
            };

            return View("MovieForm", newViewModel);
        }

        var movie = _mapper.Map<Movie>(viewModel);

        if (movie.Id == 0)
            await _movieRepository.AddAsync(movie);
        else
            await _movieRepository.UpdateAsync(movie.Id, movie);

        return RedirectToAction("Index", "Movies");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieRepository.GetAsync(id);

        if (movie == null) return NotFound();

        var viewModel = _mapper.Map<MovieFormViewModel>(movie);
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
