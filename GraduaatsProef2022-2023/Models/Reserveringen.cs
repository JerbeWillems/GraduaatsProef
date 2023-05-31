using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GraduaatsProef2022_2023.Models
{
    public class Reserveringen
    {
        [Required]
        [Key]
        public int ReserveringsId { get; set; }
        [Required]
        public string? Naam { get; set; }
        [Required]
        public DateTime? Datum { get; set; }
        [Required]
        public string? Hoelang { get; set; }
        [Required]
        public string? GeheimeCode { get; set; }
        [Required]
        public double? Prijs { get; set; }
        [Required]
        public string?  Omschrijving { get; set; }
    }
}
