using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManagement
{
    public class BankingService 
    {
        private readonly NpgsqlConnection _connection;

        public BankingService()
        {
            _connection = new NpgsqlConnection(
                GradeManagement.Constants.DatabaseConnectionConstants.connectionString
            );
            _connection.Open(); 
        }

        public async Task CreateBankAccount(BankAccount account)
        {
            var sql = "INSERT INTO BankAccounts (AccountNumber, AccountHolder, Balance) VALUES (@AccountNumber, @AccountHolder, @Balance)";
            await _connection.ExecuteAsync(sql, account);
        }

        public async Task<BankAccount> GetBankAccountById(int id)
        {
            var sql = "SELECT * FROM BankAccounts WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<BankAccount>(sql, new { Id = id });
        }

        public async Task Deposit(int accountId, decimal amount)
        {
            var account = await GetBankAccountById(accountId);
            if (account == null) throw new Exception("Account not found");

            account.Balance += amount;

            var updateSql = "UPDATE BankAccounts SET Balance = @Balance WHERE Id = @Id";
            await _connection.ExecuteAsync(updateSql, new { Balance = account.Balance, Id = accountId });

            var transactionSql = @"INSERT INTO Transactions (AccountId, TransactionType, Amount, TransactionDate)
                                   VALUES (@AccountId, @TransactionType, @Amount, @TransactionDate)";
            await _connection.ExecuteAsync(transactionSql, new
            {
                AccountId = accountId,
                TransactionType = "Deposit",
                Amount = amount,
                TransactionDate = DateTime.UtcNow
            });
        }

        public async Task Withdraw(int accountId, decimal amount)
        {
            var account = await GetBankAccountById(accountId);
            if (account == null) throw new Exception("Account not found");
            if (account.Balance < amount) throw new Exception("Insufficient funds");

            account.Balance -= amount;

            var updateSql = "UPDATE BankAccounts SET Balance = @Balance WHERE Id = @Id";
            await _connection.ExecuteAsync(updateSql, new { Balance = account.Balance, Id = accountId });

            var transactionSql = @"INSERT INTO Transactions (AccountId, TransactionType, Amount, TransactionDate)
                                   VALUES (@AccountId, @TransactionType, @Amount, @TransactionDate)";
            await _connection.ExecuteAsync(transactionSql, new
            {
                AccountId = accountId,
                TransactionType = "Withdraw",
                Amount = amount,
                TransactionDate = DateTime.UtcNow
            });
        }

      
    }
}
