using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; private set; } // private set for encapsulation
        public List<Transaction> Transactions { get; set; }

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
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            Transactions.Add(new Transaction(Guid.NewGuid().ToString(), "Withdraw", amount, DateTime.Now));
            Console.WriteLine($"Withdrew {amount:C}. New balance is {Balance:C}.");
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Account {AccountNumber} balance: {Balance:C}");
        }
    }

    public class Transaction
    {
        public string TransactionId { get; set; }
        public string Type { get; set; } 
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }

        public Transaction(string transactionId, string type, decimal amount, DateTime dateTime)
        {
            TransactionId = transactionId;
            Type = type;
            Amount = amount;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{DateTime}: {Type} of {Amount:C} (ID: {TransactionId})";
        }
    }

   
}
