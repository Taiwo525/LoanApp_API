using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace LoanApp_API.Models
{
    public class LoanApp
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

        public LoanStatus Status { get; set; }

        public List<Document> Documents { get; set; }
    }
}
