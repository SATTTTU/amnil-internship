using AppliationDemo;
using AppliationDemo.Repositories;
using AppliationDemo.DTOs;
using AppliationDemo.Models;
using System;
using System.Threading.Tasks;

namespace AppliationDemo.Services
{
    public class BankService
    {
        private readonly IBankAccountRepository _accountRepo;
        private readonly ITransactionRepository _transactionRepo;

        public BankService(IBankAccountRepository accountRepo, ITransactionRepository transactionRepo)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task CreateAccount(BankAccountDto dto)
        {
            var account = new BankAccount
            {
                AccountNumber = dto.AccountNumber,
                AccountHolder = dto.AccountHolder,
                Balance = dto.Balance
            };
            await _accountRepo.CreateAsync(account);
        }

        public async Task Deposit(TransactionDto dto)
        {
            var account = await _accountRepo.GetByIdAsync(dto.AccountId);
            if (account == null) throw new Exception("Account not found");

            account.Balance += dto.Amount;
            await _accountRepo.UpdateAsync(account);

            await _transactionRepo.AddTransactionAsync(new Transaction
            {
                AccountId = dto.AccountId,
                TransactionType = "Deposit",
                Amount = dto.Amount,
                TransactionDate = DateTime.UtcNow
            });
        }

        public async Task Withdraw(TransactionDto dto)
        {
            var account = await _accountRepo.GetByIdAsync(dto.AccountId);
            if (account == null) throw new Exception("Account not found");
            if (account.Balance < dto.Amount) throw new Exception("Insufficient funds");

            account.Balance -= dto.Amount;
            await _accountRepo.UpdateAsync(account);

            await _transactionRepo.AddTransactionAsync(new Transaction
            {
                AccountId = dto.AccountId,
                TransactionType = "Withdraw",
                Amount = dto.Amount,
                TransactionDate = DateTime.UtcNow
            });
        }
    }
}
