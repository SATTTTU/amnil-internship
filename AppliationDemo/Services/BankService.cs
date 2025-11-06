using AppliationDemo.Repositories;
using AppliationDemo.DTOs;
using AppliationDemo.Models;
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

        private string GenerateAccountNumber()
        {
            var random = new Random();
            string prefix = "BA";
            string randomDigits = random.Next(100000000, 999999999).ToString();
            string timestampPart = DateTime.UtcNow.Ticks.ToString().Substring(10, 3);
            return $"{prefix}{randomDigits}{timestampPart}";
        }

        public async Task CreateAccount(BankAccountDto dto)
        {
            var account = new BankAccount
            {
                AccountNumber = GenerateAccountNumber(),
                AccountHolder = dto.AccountHolder,
                Balance = dto.Balance
            };

            await _accountRepo.CreateAsync(account);
        }

        public async Task Deposit(TransactionDto dto)
        {
            var account = await _accountRepo.GetByIdAsync(dto.AccountId);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            account.Balance += dto.Amount;
            await _accountRepo.UpdateAsync(account);

            var transaction = new Transaction
            {
                AccountId = dto.AccountId,
                TransactionType = TransactionType.Deposit,
                Amount = dto.Amount,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepo.AddTransactionAsync(transaction);
        }

        public async Task Withdraw(TransactionDto dto)
        {
            var account = await _accountRepo.GetByIdAsync(dto.AccountId);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            if (account.Balance < dto.Amount)
            {
                throw new Exception("Insufficient funds.");
            }

            account.Balance -= dto.Amount;
            await _accountRepo.UpdateAsync(account);

            var transaction = new Transaction
            {
                AccountId = dto.AccountId,
                TransactionType = TransactionType.Withdraw,
                Amount = dto.Amount,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepo.AddTransactionAsync(transaction);
        }
    }
}
