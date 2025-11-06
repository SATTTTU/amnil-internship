using AppliationDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace AppliationDemo.DTOs
{
    public class TransactionDto
    {
        [Required(ErrorMessage = "Account ID is required.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType TransactionType { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
    }
}
