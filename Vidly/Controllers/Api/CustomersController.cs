using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vidly.DTO;
using Vidly.Models;
using Vidly.Repositories;

namespace Vidly.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync()
    {
        var customersDto = (await _customerRepository.GetAllAsync()).Select(_mapper.Map<Customer, CustomerDto>);

        return Ok(customersDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetAsync(id);

        if (customer == null) return NotFound();

        var customerDto = _mapper.Map<CustomerDto>(customer);

        return Ok(customerDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(CustomerDto customerDto)
    {
        // Validate the request
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var customer = _mapper.Map<Customer>(customerDto);

        // Pass details Repository
        var addedCustomer = await _customerRepository.AddAsync(customer);

        customerDto.Id = addedCustomer.Id;

        return CreatedAtAction(nameof(GetCustomerAsync), new { id = customerDto.Id }, customerDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] CustomerDto customerDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var customer = _mapper.Map<Customer>(customerDto);

        var updatedCustomer = await _customerRepository.UpdateAsync(id, customer);

        if (updatedCustomer == null) return NotFound();

        return Ok(updatedCustomer);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.DeleteAsync(id);

        if (customer == null) return NotFound();

        return Ok(customer);
    }
}
