using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeManagement.Services
{
    public class TransactionService
    {
        public async Task GetTransactionsByAccountId(int accountId)
        {
            using (var connection = new NpgsqlConnection(GradeManagement.Constants.DatabaseConnectionConstants.connectionString))
            {
                var sql = "SELECT * FROM Transactions WHERE AccountId = @AccountId ORDER BY TransactionDate DESC";
                var transactions = await connection.QueryAsync<Transactions>(sql, new { AccountId = accountId });

                if (transactions == null || !transactions.Any())
                {
                    Console.WriteLine("\nNo transactions found for this account.");
                    return;
                }

                Console.WriteLine($"\n Transactions for Account ID: {accountId}");
                Console.WriteLine(new string('-', 60));
                Console.WriteLine($"{"Transaction ID",-15} {"Type",-15} {"Amount",-15} {"Date"}");
                Console.WriteLine(new string('-', 60));

                foreach (var t in transactions)
                {
                    Console.WriteLine($"{t.TransactionId,-15} {t.TransactionType,-15} {t.Amount,-15:C} {t.TransactionDate}");
                }

                Console.WriteLine(new string('-', 60));
            }
        }
    }
}
