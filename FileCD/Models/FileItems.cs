using System.ComponentModel.DataAnnotations;

namespace FileCD.Models
{
    public class FileItems
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
