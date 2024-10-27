using CoreBankingAppYT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBankingAppYT.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer Customer);
        Task<List<Customer>> GetAllAsync();


        //UPDATE OPERATION
        Task<Customer?> GetByIdAsync(int id);
        Task UpdateAsync(Customer Customer);

        Task DeleteByIdAsync(int id);
    
    }
}
