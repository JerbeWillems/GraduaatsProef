﻿using GraduaatsProef2022_2023.Models;
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

                if (!_context.Reserveringen.Any())
                {
                    foreach (var topic in GetReserveringen())
                    {
                        _context.Reserveringen.Add(topic);
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
                Omschrijving = "Deze les gaat over wat voor Testen er allemaal zijn en hoe u deze test kunt gebruiken.",
                Actie = "Testing"
            };
            result[1] = new Onderwerpen
            {
                Naam = "Test Authomation",
                Omschrijving = "Deze les gaat over de test Test Authomation en hoe u deze test kunt gebruiken.",
                Actie = "TestAuthomation"
            };
            result[2] = new Onderwerpen
            {
                Naam = "Security Testing",
                Omschrijving = "Deze les gaat over de test Security Testing en hoe u deze test kunt gebruiken.",
                Actie = "SecurityTesting"
            };
            result[3] = new Onderwerpen
            {
                Naam = "Flex Testing",
                Omschrijving = "Deze les gaat over de test Flex Testing en hoe u deze test kunt gebruiken.",
                Actie = "FlexTesting"
            };
            result[4] = new Onderwerpen
            {
                Naam = "Unit Testing",
                Omschrijving = "Deze les gaat over de test Unit Testing en hoe u deze test kunt gebruiken.",
                Actie = "PerformanceTesting"
            };
            result[5] = new Onderwerpen
            {
                Naam = "PEN Testing",
                Omschrijving = "Deze les gaat over PEN Testing, waarvoor PEN staat en hoe u deze test kunt gebruiken.",
                Actie = "ScalabilityTesting"
            };
            return result;
        }
        public static Reserveringen[] GetReserveringen()
        {
            var result = new Reserveringen[1];
            result[0] = new Reserveringen
            {
                Naam = "Testing",
                Omschrijving = "Deze les gaat over wat voor Testen er allemaal zijn en hoe u deze test kunt gebruiken.",
                Datum = DateTime.Parse("17/05/2023"),
                Hoelang = "1 uur",
                GeheimeCode = "458PGT",
                Prijs = 10,              
            };
            return result;
        }

    }
}