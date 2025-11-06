using System.ComponentModel.DataAnnotations;

namespace AppliationDemo.DTOs
{
    public class BankAccountDto
    {
        [Required(ErrorMessage = "Account Holder Name is required.")]
        [StringLength(100, ErrorMessage = "Account Holder Name cannot exceed 100 characters.")]
        public string AccountHolder { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive value.")]
        public decimal Balance { get; set; }
    }
}
