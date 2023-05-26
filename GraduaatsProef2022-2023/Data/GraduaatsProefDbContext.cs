using GraduaatsProef2022_2023.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduaatsProef2022_2023.Data
{
    public class GraduaatsProefDbContext : IdentityDbContext
    {
        public GraduaatsProefDbContext(DbContextOptions<GraduaatsProefDbContext> options): base(options) 
        {

        }
        public DbSet<Onderwerpen> Onderwerpen { get; set; }
        public DbSet<Reserveringen> Reserveringen { get; set; }
        public DbSet <Account> Account { get; set; }
        public DbSet <UserIndex> UserIndex { get; set; }
    }
}
