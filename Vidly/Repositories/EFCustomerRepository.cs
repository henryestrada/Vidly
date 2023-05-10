using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Repositories;

public class EFCustomerRepository : ICustomerRepository
{
    private readonly VidlyDbContext _vidlyDbContext;

    public EFCustomerRepository(VidlyDbContext vidlyDbContext)
    {
        _vidlyDbContext = vidlyDbContext;
    }
    public async Task<Customer> AddAsync(Customer customer)
    {
        customer.Id = 0;
        await _vidlyDbContext.AddAsync(customer);
        await _vidlyDbContext.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> DeleteAsync(int id)
    {
        var customer = await _vidlyDbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);

        if (customer == null) return null;

        _vidlyDbContext.Customers.Remove(customer);

        await _vidlyDbContext.SaveChangesAsync();

        return customer;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _vidlyDbContext.Customers.Include(c => c.MembershipType).ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetAsync(string query)
    {
        return await _vidlyDbContext.Customers.Include(c => c.MembershipType).Where(c => c.FirstName.Contains(query) || c.LastName.Contains(query)).ToListAsync();
    }

    public async Task<Customer> GetAsync(int id)
    {
        return await _vidlyDbContext.Customers.Include(c => c.MembershipType).SingleAsync(x => x.Id == id);
    }

    public async Task<Customer> UpdateAsync(int id, Customer customer)
    {
        var existingCustomer = await _vidlyDbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);

        if (existingCustomer == null) return null;

        existingCustomer.FirstName = customer.FirstName;
        existingCustomer.LastName = customer.LastName;
        existingCustomer.Birthdate = customer.Birthdate;
        existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        existingCustomer.MembershipType = customer.MembershipType;

        await _vidlyDbContext.SaveChangesAsync();

        return existingCustomer;
    }
}