using System;
using System.ComponentModel.DataAnnotations;

namespace AppliationDemo.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Account ID is required.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Transaction Type is required.")]
        [StringLength(10, ErrorMessage = "Transaction Type cannot exceed 10 characters.")]
        public string TransactionType { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; }
    }
}
