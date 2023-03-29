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

    public Task<Customer> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _vidlyDbContext.Customers.Include(c => c.MembershipType).ToListAsync();
    }

    public async Task<Customer> GetAsync(int id)
    {
        return await _vidlyDbContext.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Customer> UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}