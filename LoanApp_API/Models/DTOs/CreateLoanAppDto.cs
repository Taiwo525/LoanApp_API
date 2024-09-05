using System.ComponentModel.DataAnnotations;

namespace LoanApp_API.Models.DTOs
{
    public class CreateLoanAppDto
    {
        [Required]
        public string ApplicantName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public int LoanTermMonths { get; set; }
    }
}
