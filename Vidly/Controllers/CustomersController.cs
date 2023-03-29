using Microsoft.AspNetCore.Mvc;
using Vidly.Repositories;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ViewResult> Index()
        {
            var customers = await _customerRepository.GetAllAsync();

            return View("Customers", customers);
        }

        [Route("Customers/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerRepository.GetAsync(id);

            if (customer == null) return NotFound();

            return View("Details", customer);
        }
    }
}