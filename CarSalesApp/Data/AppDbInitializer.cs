using CarSalesApp.Data.Enums;
using CarSalesApp.Data.Static;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarSalesApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CarSalesAppContext>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                context.Database.EnsureCreated();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                // Branch
                if (!context.Branches.Any())
                {
                    context.Branches.AddRange(new List<Branch>()
                    {
                        new Branch()
                        {
                            Name = "Branch 1",
                            Logo = "https://i.postimg.cc/VvWVPKpV/dealer1.jpg",
                            Description = "This is the description of our first branch"
                        },
                        new Branch()
                        {
                            Name = "Branch 2",
                            Logo = "https://i.postimg.cc/VvWVPKpV/dealer2.jpg",
                            Description = "This is the description of our second branch"
                        },
                        new Branch()
                        {
                            Name = "Branch 3",
                            Logo = "https://i.postimg.cc/VvWVPKpV/dealer3.jpg",
                            Description = "This is the description of our third branch"
                        },
                        new Branch()
                        {
                            Name = "Branch 4",
                            Logo = "https://i.postimg.cc/VvWVPKpV/dealer4.jpg",
                            Description = "This is the description of our fourth branch"
                        },
                        new Branch()
                        {
                            Name = "Branch 5",
                            Logo = "https://i.postimg.cc/VvWVPKpV/dealer1.jpg",
                            Description = "This is the description of our fifth branch"
                        },
                    });
                    context.SaveChanges();
                }
                //Car
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                    {
                     new Car()
                        {
                            Make = "Mercedes-Benz",
                            Model = "AMG GT",
                            Colour = "Red",
                            Year = 2021,
                            Description = "Beautiful red sports car, owned by a careful driver",
                            Price = 2000.00,
                            ImageURL = "https://i.postimg.cc/MpDK3tvv/Mercedes-sports.jpg",
                            ListDate = DateTime.Now.AddDays(-7),
                            AvailableDate = DateTime.Now.AddDays(11),
                             Condition = Condition.Used,
                            BodyType = BodyType.Supercar,
                            BranchId = 3


                        },
                     new Car()
                        {
                            Make = "Ford",
                            Model = "Mustang",
                            Colour = "Grey",
                            Year = 2019,
                            Description = "Beautiful grey sports car, owned by a careful driver",
                            Price = 2000.00,
                            ImageURL = "https://i.postimg.cc/KvtYBmb7/Mustang.jpg",
                            ListDate = DateTime.Now.AddDays(-10),
                            AvailableDate = DateTime.Now.AddDays(10),
                             Condition = Condition.Used,
                            BodyType = BodyType.Sportscar,
                            BranchId = 3


                        },
                     new Car()
                        {
                            Make = "Audi",
                            Model = "R8",
                            Colour = "Grey",
                            Year = 2021,
                            Description = "Beautiful greysports car, owned by a careful driver",
                            Price = 2000.00,
                            ImageURL = "https://i.postimg.cc/VNmmjtgm/AudiR8.jpg",
                            ListDate = DateTime.Now.AddDays(-10),
                            AvailableDate = DateTime.Now.AddDays(10),
                            Condition = Condition.Used,
                            BodyType = BodyType.Sportscar,
                            BranchId = 3

                        },
                     new Car()
                        {
                            Make = "Fiat",
                            Model = "500",
                            Colour = "Blue",
                            Year = 2017,
                            Description = "Beautiful blue zippy car, owned by a careful driver",
                            Price = 2000.00,
                            ImageURL = "https://i.postimg.cc/nLhVy7DT/fiat500.jpg",
                            ListDate = DateTime.Now.AddDays(-10),
                            AvailableDate = DateTime.Now.AddDays(10),
                            Condition = Condition.Used,
                            BodyType = BodyType.Hatchback,
                            BranchId = 3

                        },
                     new Car()
                        {
                            Make = "Lamborghini",
                            Model = "Hurracan",
                            Colour = "Green",
                            Year = 2021,
                            Description = "Beautiful ash sports car, owned by a careful driver",
                            Price = 2000.00,
                            ImageURL = "https://i.postimg.cc/qRgfLx3V/Hurracan.jpg",
                            ListDate = DateTime.Now.AddDays(-10),
                            AvailableDate = DateTime.Now.AddDays(10),
                            Condition = Condition.Used,
                            BodyType = BodyType.Supercar,
                            BranchId = 3

                        },
                     new Car()
                        {
                            Make = "Lamborghini",
                            Model = "Hurracan",
                            Colour = "Green",
                            Year = 2021,
                            Description = "Beautiful ash sports car, owned by a careful driver",
                            Price = 2000.00,
                            ImageURL = "https://i.postimg.cc/qRgfLx3V/Hurracan.jpg",
                            ListDate = DateTime.Now.AddDays(-10),
                            AvailableDate = DateTime.Now.AddDays(10),
                            Condition = Condition.Used,
                            BodyType = BodyType.Supercar,
                            BranchId = 3

                        }
                    });
                    context.SaveChanges();
                }

                //Manufacturer
                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.AddRange(new List<Manufacturer>()
                    {

                        new Manufacturer()
                        {
                            LogoURL = "https://i.postimg.cc/9QZcw233/BigBMW.jpg",
                            Name = "BMW",
                            Address = "This is the Manufacturer's Address"
                        },
                        new Manufacturer()
                        {
                            LogoURL = "https://i.postimg.cc/RFsmxVtt/BigCHEVY.jpg",
                            Name = "CHEVROLET",
                            Address = "This is the Manufacturer's Address"
                        },
                        new Manufacturer()
                        {
                            LogoURL = "https://i.postimg.cc/vTCdDq3H/Big-HYUNDAI.jpg",
                            Name = "HYUNDAI",
                            Address = "This is the Manufacturer's Address"
                        },
                        new Manufacturer()
                        {
                            LogoURL = "https://i.postimg.cc/02Jshvy6/Big-PORSCHE.jpg",
                            Name = "PORSCHE",
                            Address = "This is the Manufacturer's Address"
                        },
                        new Manufacturer()
                        {
                            LogoURL = "https://i.postimg.cc/m2cLRM8g/BigTESLA.jpg",
                            Name = "TESLA",
                            Address = "This is the Manufacturer's Address"
                        },
                        new Manufacturer()
                        {
                            LogoURL = "https://i.postimg.cc/GpRdkfr4/BigMERC.jpg",
                            Name = "MERCEDES",
                            Address = "This is the Manufacturer's Address"
                        },
                    });
                    context.SaveChanges();
                }
                //Salesman
                if (!context.Salesmen.Any())
                {
                    context.Salesmen.AddRange(new List<Salesman>()
                    {
                        new Salesman()
                        {
                            ProfilePicURL= "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Name = "John Doe",
                            PhoneNumber = 1234567890,
                            Address = "This is the address of the salesman",
                            Email= "Salesman1@carsales.com"
                        },
                        new Salesman()
                        {
                            ProfilePicURL= "http://dotnethow.net/images/actors/actor-2.jpeg",
                            Name = "Alex Doe",
                            PhoneNumber = 1234567894,
                            Address = "This is the address of the salesman",
                            Email= "Salesman2@carsales.com"
                        },

                        new Salesman()
                        {
                            ProfilePicURL= "http://dotnethow.net/images/actors/actor-3.jpeg",
                            Name = "Ethan Doe",
                            PhoneNumber = 1234567891,
                            Address = "This is the address of the salesman",
                            Email= "Salesman3@carsales.com"
                        },
                        new Salesman()
                        {
                            ProfilePicURL= "http://dotnethow.net/images/actors/actor-4.jpeg",
                            Name = "Nicky Doe",
                            PhoneNumber = 1234567892,
                            Address = "This is the address of the salesman",
                            Email= "Salesman4@carsales.com"
                        },
                        new Salesman()
                        {
                            ProfilePicURL= "http://dotnethow.net/images/actors/actor-5.jpeg",
                            Name = "Mike Doe",
                            PhoneNumber = 1234567893,
                            Address = "This is the address of the salesman",
                            Email= "Salesman5@carsales.com"
                        }
                    });
                    context.SaveChanges();


                }
            }
        }


            public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }








   


