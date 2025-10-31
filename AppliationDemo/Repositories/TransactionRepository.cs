using AppliationDemo.Repositories;
using AppliationDemo.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppliationDemo.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = @"INSERT INTO Transactions (AccountId, TransactionType, Amount, TransactionDate)
                        VALUES (@AccountId, @TransactionType, @Amount, @TransactionDate)";
            await connection.ExecuteAsync(sql, transaction);
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM Transactions WHERE AccountId = @AccountId ORDER BY TransactionDate DESC";
            return await connection.QueryAsync<Transaction>(sql, new { AccountId = accountId });
        }
    }
}
