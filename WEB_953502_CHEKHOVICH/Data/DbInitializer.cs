using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }

            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.ComputerGroups.Any())
            {
                context.ComputerGroups.AddRange(
                    new List<ComputerGroup>
                    {
                        new ComputerGroup {GroupName = "Ноутбуки"},
                        new ComputerGroup {GroupName = "Компьютеры"},
                        new ComputerGroup {GroupName = "Моноблоки"},
                    });
                await context.SaveChangesAsync();
            }

            if (!context.Computers.Any())
            {
                context.Computers.AddRange(
                    new List<Computer>()
                    {
                        new Computer {Name = "Jet Gamer 5i10400FD16SD24X105TL2W5", CPU = "Intel Core i5 10400F 2900 МГц", Price = 2180,
                            GraphicsCard = "NVIDIA GeForce GTX 1050 Ti 4 ГБ", RAM = 16, Image = "JetComputer.jpg", ComputerGroupId = 2},
                        new Computer {Name = "FK BY X-Game 138365", CPU = "Intel Core i5 10400F 2900 МГц", Price = 3200,
                            GraphicsCard = "NVIDIA GeForce GTX 1650 Super 4 ГБ", RAM = 16, Image = "FKComputer.jpg", ComputerGroupId = 2},
                        new Computer {Name = "ASUS X515MA-EJ017", CPU = "Intel Celeron N4020 1100 МГц", Price = 885,
                            GraphicsCard = "Видеокарта встроенная", RAM = 4, Image = "AsusLaptop.jpg", ComputerGroupId = 1},
                        new Computer {Name = "Lenovo IdeaPad 3 15ITL6 82H800JSRE", CPU = "Intel Core i5 1135G7 2400 МГц", Price = 1800,
                            GraphicsCard = "NVIDIA GeForce MX350 2 ГБ", RAM = 8, Image = "LenovoLaptop.jpg", ComputerGroupId = 1},
                        new Computer {Name = "HP 27-dp0060ur 30C81EA", CPU = "AMD Ryzen 3 4300U 2700 МГц", Price = 2050,
                            GraphicsCard = "Видеокарта встроенная", RAM = 8, Image = "HPMonoblock.jpg", ComputerGroupId = 3},
                        new Computer {Name = "Apple iMac 27\" Retina 5K 2020 MXWT2", CPU = "Intel Core i5 10500 3100 МГц", Price = 5900,
                            GraphicsCard = "AMD Radeon Pro 5300 4ГБ", RAM = 8, Image = "AppleMonoblock.jpg", ComputerGroupId = 3},
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
