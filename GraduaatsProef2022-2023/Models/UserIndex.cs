using System.ComponentModel.DataAnnotations;

namespace GraduaatsProef2022_2023.Models
{
    public class UserIndex
    {
        [Required]
        [Key]
        public int UserIndexId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Naam { get; set; }
        [Required]
        public string? Omschrijving { get; set; }
        [Required]
        public DateTime? Datum { get; set; }
        [Required]
        public string? Hoelang { get; set; }
        [Required]
        public string? GeheimeCode { get; set; }
        [Required]
        public double? Prijs { get; set; }



    }
}
