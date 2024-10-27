using CoreBankingAppYT.Application.Interfaces;
using CoreBankingAppYT.Domain.Entities;
using CoreBankingAppYT.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CoreBankingAppYT.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankingDbContext _context;

        public CustomerRepository(IDbContextFactory<BankingDbContext> factory)
        {
            _context = factory.CreateDbContext();
        }
        public async Task AddAsync(Customer Customer)
        {
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer is not null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
           var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task UpdateAsync(Customer Customer)
        {
            _context.Entry(Customer).State = EntityState.Modified;
            await  _context.SaveChangesAsync();
        }
    }
}
