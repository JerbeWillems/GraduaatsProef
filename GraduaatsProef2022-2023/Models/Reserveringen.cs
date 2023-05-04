using System.ComponentModel.DataAnnotations;

namespace GraduaatsProef2022_2023.Models
{
    public class Reserveringen
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Foto { get; set; }
        [Required]
        public string GeheimeCode { get; set; }
        [Required]
        public double Prijs { get; set; }
        [Required]
        public string  Omschrijving { get; set; }
    }
}
