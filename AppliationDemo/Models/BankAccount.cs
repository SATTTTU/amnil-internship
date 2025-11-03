using System.ComponentModel.DataAnnotations;

namespace AppliationDemo.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Account Number is required.")]
        [StringLength(20, ErrorMessage = "Account Number cannot exceed 20 characters.")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Holder Name is required.")]
        [StringLength(100, ErrorMessage = "Account Holder Name cannot exceed 100 characters.")]
        public string AccountHolder { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive value.")]
        public decimal Balance { get; set; }
    }
}
