using AppliationDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppliationDemo.Repositories
{
    public interface IBankAccountRepository
    {
        Task CreateAsync(BankAccount account);
        Task<BankAccount> GetByIdAsync(int id);
        Task<IEnumerable<BankAccount>> GetAllAsync();
        Task UpdateAsync(BankAccount account);
    }
}
