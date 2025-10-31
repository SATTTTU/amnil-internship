using AppliationDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppliationDemo.Repositories
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId);
    }
}
