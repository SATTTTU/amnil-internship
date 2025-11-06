using System;
using System.ComponentModel.DataAnnotations;



    namespace AppliationDemo.Models
    {
        public class Transaction
        {
            public int TransactionId { get; set; }

            public int AccountId { get; set; }

            public TransactionType TransactionType { get; set; }

            public decimal Amount { get; set; }

            public DateTime TransactionDate { get; set; }
        }
    

    public enum TransactionType
        {
            Deposit = 1,
            Withdraw = 2
        }

}
