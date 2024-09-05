using System.ComponentModel.DataAnnotations;

namespace LoanApp_API.Models.DTOs
{
    public class LoanAppDto
    {
        public int Id { get; set; }

        [Required]
        public string ApplicantName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public int LoanTermMonths { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; }

        public List<DocumentDto> Documents { get; set; }
    }
}
