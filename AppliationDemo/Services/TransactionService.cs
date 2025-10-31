using AppliationDemo.Models;
using AppliationDemo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppliationDemo.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IBankAccountRepository _accountRepo;

        public TransactionService(ITransactionRepository transactionRepo, IBankAccountRepository accountRepo)
        {
            _transactionRepo = transactionRepo;
            _accountRepo = accountRepo;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int accountId)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null)
                throw new System.Exception("Account not found.");

            return await _transactionRepo.GetByAccountIdAsync(accountId);
        }
    }
}
