using System;
using System.Threading.Tasks;
using GradeManagement.Services; 

using Dapper;
using Npgsql;

namespace GradeManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var bankingService = new BankingService();
            var transactionService = new TransactionService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Create Bank Account");
                Console.WriteLine("2. View Bank Account by ID");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. View All Transactions by Account ID");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            await CreateAccount(bankingService);
                            break;
                        case "2":
                            await ViewAccount(bankingService);
                            break;
                        case "3":
                            await Deposit(bankingService);
                            break;
                        case "4":
                            await Withdraw(bankingService);
                            break;
                        case "5":
                            await GetTransactionsByAccount(transactionService);
                            break;
                        case "0":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static async Task CreateAccount(BankingService bankingService)
        {
            Console.Write("Enter Account Number: ");
            var accountNumber = Console.ReadLine();

            Console.Write("Enter Account Holder Name: ");
            var accountHolder = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            var balance = decimal.Parse(Console.ReadLine());

            var account = new BankAccount
            {
                AccountNumber = accountNumber,
                AccountHolder = accountHolder,
                Balance = balance
            };

            await bankingService.CreateBankAccount(account);
            Console.WriteLine(" Account created successfully!");
        }

        private static async Task ViewAccount(BankingService bankingService)
        {
            Console.Write("Enter Account ID: ");
            int id = int.Parse(Console.ReadLine());
            var account = await bankingService.GetBankAccountById(id);

            if (account == null)
                Console.WriteLine("Account not found.");
            else
                Console.WriteLine($"ID: {account.Id}, Number: {account.AccountNumber}, Holder: {account.AccountHolder}, Balance: {account.Balance}");
        }

        private static async Task Deposit(BankingService bankingService)
        {
            Console.Write("Enter Account ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Deposit Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            await bankingService.Deposit(id, amount);
            Console.WriteLine(" Deposit successful!");
        }

        private static async Task Withdraw(BankingService bankingService)
        {
            Console.Write("Enter Account ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Withdrawal Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            await bankingService.Withdraw(id, amount);
            Console.WriteLine(" Withdrawal successful!");
        }

        private static async Task GetTransactionsByAccount(TransactionService transactionService)
        {
            Console.Write("Enter Account ID: ");
            int accountId = int.Parse(Console.ReadLine());

            await transactionService.GetTransactionsByAccountId(accountId);
        }

    }




}
