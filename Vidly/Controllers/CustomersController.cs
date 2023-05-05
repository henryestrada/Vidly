using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.ViewModels;

namespace Vidly.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
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
        return View("Customers");
    }

    public async Task<ViewResult> New()
    {
        var membershipTypes = await _membershipTypeRepository.GetAllAsync();
        var viewModel = new CustomerFormViewModel
        {
            Customer = new Models.Customer(),
            MembershipTypes = membershipTypes
        };

        return View("CustomerForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            var newViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = await _membershipTypeRepository.GetAllAsync()
            };

            return View("CustomerForm", newViewModel);
        }

        //var customer = viewModel.Customer;

        if (customer.Id == 0)
            await _customerRepository.AddAsync(customer);
        else
            await _customerRepository.UpdateAsync(customer.Id, customer);

        return RedirectToAction("Index", "Customers");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerRepository.GetAsync(id);

        if (customer == null) return NotFound();

        var viewModel = new CustomerFormViewModel
        {
            Customer = customer,
            MembershipTypes = await _membershipTypeRepository.GetAllAsync()
        };

        return View("CustomerForm", viewModel);
    }

    [Route("Customers/Details/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var customer = await _customerRepository.GetAsync(id);

        if (customer == null) return NotFound();

        return View("Details", customer);
    }
}