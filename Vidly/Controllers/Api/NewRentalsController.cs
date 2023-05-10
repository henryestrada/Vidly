using Microsoft.AspNetCore.Mvc;
using Vidly.DTO;
using Vidly.Models;
using Vidly.Repositories;

namespace Vidly.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class NewRentalsController : ControllerBase
{
    private readonly IRentalRepository _rentalRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMovieRepository _movieRepository;

    public NewRentalsController(
        IRentalRepository rentalRepository,
        ICustomerRepository customerRepository,
        IMovieRepository movieRepository)
    {
        _rentalRepository = rentalRepository;
        _customerRepository = customerRepository;
        _movieRepository = movieRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewRentals(NewRentalDto newRental)
    {
        var customer = await _customerRepository.GetAsync(newRental.CustomerId);
        var movies = await _movieRepository.GetAsync(newRental.MovieIdCollection);

        foreach (var movie in movies)
        {
            if (movie.NumberAvailable == 0)
                return BadRequest("Movie is not available");

            var rental = new Rental
            {
                Customer = customer,
                Movie = movie,
                DateRented = DateTime.Now,
                DateReturned = null
            };

            await _rentalRepository.AddAsync(rental);
        }

        return Ok();
    }
}
