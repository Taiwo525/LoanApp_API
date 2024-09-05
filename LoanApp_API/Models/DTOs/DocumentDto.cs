using System.ComponentModel.DataAnnotations;

namespace LoanApp_API.Models.DTOs
{
    public class DocumentDto
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public string FileUrl { get; set; }
    }
}
