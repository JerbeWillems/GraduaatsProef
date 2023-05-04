using System.ComponentModel.DataAnnotations;

namespace GraduaatsProef2022_2023.Models
{
    public class Onderwerpen
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        public string Foto { get; set; }
    }
}
