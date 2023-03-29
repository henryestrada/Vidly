using Microsoft.AspNetCore.Mvc;
using Vidly.Repositories;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public CustomersController(ICustomerRepository customerRepository, IMembershipTypeRepository membershipTypeRepository)
        {
            _customerRepository = customerRepository;
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<ViewResult> Index()
        {
            var customers = await _customerRepository.GetAllAsync();

            return View("Customers", customers);
        }

        public async Task<ViewResult> New()
        {
            var membershipTypes = await _membershipTypeRepository.GetAllAsync();
            var viewModel = new NewCustomerViewModel { MembershipTypes = membershipTypes };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCustomerViewModel viewModel)
        {
            await _customerRepository.AddAsync(viewModel.Customer);

            return RedirectToAction("Index", "Customers");
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