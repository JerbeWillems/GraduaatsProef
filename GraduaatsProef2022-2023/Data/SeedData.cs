using GraduaatsProef2022_2023.Models;
using Microsoft.AspNetCore.Identity;

namespace GraduaatsProef2022_2023.Data
{
    public static class SeedData
    {
        static GraduaatsProefDbContext? _context;
        static RoleManager<IdentityRole>? _roleManager;
        static UserManager<IdentityUser>? _userManager;
        public static async Task EnsurePopulatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                _context = scope.ServiceProvider.GetRequiredService<GraduaatsProefDbContext>();
                _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!_context.UserRoles.Any())
                {
                    IdentityRole admin = new IdentityRole()
                    {
                        Name = "Admin",
                    };
                    IdentityResult result = await _roleManager.CreateAsync(admin);
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Code);
                    }

                    IdentityUser admin1 = new IdentityUser()
                    {
                        UserName = "Admin1.First@pxl.be",
                        Email = "Admin1.First@pxl.be"
                    };

                    IdentityResult result3 = await _userManager.CreateAsync(admin1, "Admin1F!");

                    if (!result3.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Code);
                    }

                    result3 = await _userManager.AddToRoleAsync(admin1, "Admin");

                    if (!result3.Succeeded)
                    {
                        throw new Exception(result3.Errors.First().Code);
                    }

                }

                if (!_context.Onderwerpen.Any())
                {
                foreach (var topic in GetOnderwerpen())
                {
                     _context.Onderwerpen.Add(topic);
                }
                 _context.SaveChanges();
                }
            }
        }
        public static Onderwerpen[] GetOnderwerpen()
        {
            var result = new Onderwerpen[6];
            result[0] = new Onderwerpen
            {
                Naam = "Testing",
                Omschrijving = "Deze les gaat over wat Testing is en hoe u deze kunt gebruiken. Voor extra info, klik op het onderwerp",
                Foto = "../images/Testing.JPG",
                Actie = "Testing"
            };
            result[1] = new Onderwerpen
            {
                Naam = "Test Authomation",
                Omschrijving = "Deze les gaat over wat Testing is en hoe u deze kunt gebruiken. Voor extra info, klik op het onderwerp",
                Foto = "../images/Testing.JPG",
                Actie = "TestAuthomation"
            };
            result[2] = new Onderwerpen
            {
                Naam = "Security Testing",
                Omschrijving = "Deze les gaat over wat Testing is en hoe u deze kunt gebruiken. Voor extra info, klik op het onderwerp",
                Foto = "../images/Testing.JPG",
                Actie = "SecurityTesting"
            };
            result[3] = new Onderwerpen
            {
                Naam = "Flex Testing",
                Omschrijving = "Deze les gaat over wat Testing is en hoe u deze kunt gebruiken. Voor extra info, klik op het onderwerp",
                Foto = "../images/Testing.JPG",
                Actie = "FlexTesting"
            };
            result[4] = new Onderwerpen
            {
                Naam = "Performance Testing",
                Omschrijving = "Deze les gaat over wat Testing is en hoe u deze kunt gebruiken. Voor extra info, klik op het onderwerp",
                Foto = "../images/Testing.JPG",
                Actie = "PerformanceTesting"
            };
            result[5] = new Onderwerpen
            {
                Naam = "Scalability Testing",
                Omschrijving = "Deze les gaat over wat Testing is en hoe u deze kunt gebruiken. Voor extra info, klik op het onderwerp",
                Foto = "../images/Testing.JPG",
                Actie = "ScalabilityTesting"
            };
            return result;
        }
    }
}