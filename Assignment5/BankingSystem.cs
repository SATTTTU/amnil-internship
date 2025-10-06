using System;
using System.Collections.Generic;

namespace Assignment5
{
  

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
