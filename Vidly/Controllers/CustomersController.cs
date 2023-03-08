using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly List<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            },

            new Customer
            {
                Id = 2,
                FirstName = "Mary",
                LastName = "Williams"
            }
        };

        public IActionResult Index()
        {
            return View("Customers", _customers);
        }

        [Route("Customers/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var customer = _customers.Single(x => x.Id == id);

            return View("Details", customer);
        }
    }
}
