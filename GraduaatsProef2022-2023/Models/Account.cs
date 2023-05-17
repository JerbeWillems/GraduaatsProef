using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NuGet.Packaging.PackagingConstants;

namespace GraduaatsProef2022_2023.Models
{
    public class Account
    {
        [Required]
        [Key]
        public int AccountId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int? ReserveringsId { get; set; }
        [ForeignKey("ReserveringsId")]
        [ValidateNever]
        public Reserveringen? Reserveringen { get; set; }
    }
}
