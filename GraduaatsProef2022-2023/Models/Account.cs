using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GraduaatsProef2022_2023.Models
{
    public class Account
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
