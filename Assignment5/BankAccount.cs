using System;
using System.Collections.Generic;
namespace Assignment5
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public string HolderName { get; }
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; }

        public BankAccount(string accountNumber, string holderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = initialBalance;
            Transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            Transactions.Add(new Transaction(Guid.NewGuid().ToString(), "Deposit", amount, DateTime.Now));
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            Transactions.Add(new Transaction(Guid.NewGuid().ToString(), "Withdraw", amount, DateTime.Now));
            Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Account {AccountNumber} balance: {Balance:C}");
        }
    }
}
