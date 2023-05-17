using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static NuGet.Packaging.PackagingConstants;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduaatsProef2022_2023.Models
{
    public class UserReservations
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Account? User { get; set; }
        public int ReserveringsId { get; set; }
        [ForeignKey("ReserveringsId")]
        [ValidateNever]
        public Reserveringen? Reservering { get; set; }
    }
}
