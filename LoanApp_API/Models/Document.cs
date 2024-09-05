using System.ComponentModel.DataAnnotations;

namespace LoanApp_API.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public string FileUrl { get; set; }

        public int LoanAppId { get; set; }
        public LoanApp LoanApp { get; set; }
    }
}
