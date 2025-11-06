using AppliationDemo.Models;
using AppliationDemo.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppliationDemo.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly string _connectionString;

        public BankAccountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateAsync(BankAccount account)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = "INSERT INTO BankAccounts (AccountNumber, AccountHolder, Balance) VALUES (@AccountNumber, @AccountHolder, @Balance)";
            await connection.ExecuteAsync(sql, account);
        }

        public async Task<BankAccount> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM BankAccounts WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<BankAccount>(sql, new { Id = id });
        }


        public async Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<BankAccount>("SELECT * FROM BankAccounts");
        }

        public async Task UpdateAsync(BankAccount account)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = "UPDATE BankAccounts SET Balance = @Balance WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { account.Balance, account.Id });
        }
    }
}
