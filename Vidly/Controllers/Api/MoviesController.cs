using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vidly.DTO;
using Vidly.Models;
using Vidly.Repositories;

namespace Vidly.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MoviesController(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetMoviesAsync(string query = null)
    {
        IEnumerable<MovieDto> moviesDto;

        if (query == null)
            moviesDto = (await _movieRepository.GetAllAsync()).Select(_mapper.Map<Movie, MovieDto>);

        else
            moviesDto = (await _movieRepository.GetAsync(query)).Select(_mapper.Map<Movie, MovieDto>);

        return Ok(moviesDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetMovieAsync(int id)
    {
        var movie = await _movieRepository.GetAsync(id);

        if (movie == null) return NotFound();

        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPost]
    [Authorize(Roles = RoleName.CanManageMovies)]
    public async Task<IActionResult> CreateMovieAsync(AddMovieRequest addMovieDto)
    {
        // Validate the request
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var movie = _mapper.Map<Movie>(addMovieDto);

        // Pass details Repository
        var addedMovie = await _movieRepository.AddAsync(movie);

        var movieDto = _mapper.Map<MovieDto>(addedMovie);

        return CreatedAtAction(nameof(GetMovieAsync), new { id = movieDto.Id }, movieDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = RoleName.CanManageMovies)]
    public async Task<IActionResult> UpdateMovieAsync([FromRoute] int id, [FromBody] MovieDto movieDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var movie = _mapper.Map<Movie>(movieDto);

        var updatedMovie = await _movieRepository.UpdateAsync(id, movie);

        if (updatedMovie == null) return NotFound();

        return Ok(updatedMovie);
    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize(Roles = RoleName.CanManageMovies)]
    public async Task<IActionResult> DeleteMovieAsync(int id)
    {
        var movie = await _movieRepository.DeleteAsync(id);

        if (movie == null) return NotFound();

        return Ok(movie);
    }
}
