using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WachtWoord.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        public string? URL { get; set; }
        public string? Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int Strength { get; set; }
        [Required]
        [NotMapped]
        [Range(16, 128, 
            ErrorMessage = "Password length must be between 16 and 128 characters")]
        [RegularExpression(@"^[0-9]+$", 
            ErrorMessage = "Length can only contain numbers")]
        public int Length { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
