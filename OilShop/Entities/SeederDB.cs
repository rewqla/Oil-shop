using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilShop.Entities
{
    public class SeederDB
    {
        public static void SeedData(IServiceProvider services,
            IWebHostEnvironment env, IConfiguration config)
        {
            try
            {
                using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                    var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var roleName = "Admin";
                    var result = managerRole.CreateAsync(new DbRole
                    {
                        Name = roleName
                    }).Result;

                    string email = "admin@gmail.com";
                    var user = new DbUser
                    {
                        Email = email,
                        UserName = email,
                        FullName = "Stepan New",
                        PhoneNumber = "+380974355566"
                    };
                    result = manager.CreateAsync(user, "12345678").Result;
                    result = manager.AddToRoleAsync(user, roleName).Result;

                    roleName = "User";
                    result = managerRole.CreateAsync(new DbRole
                    {
                        Name = roleName
                    }).Result;

                    email = "user@gmail.com";
                    user = new DbUser
                    {
                        Email = email,
                        UserName = email,
                        FullName = "Valera New",
                        PhoneNumber = "+380974355116"
                    };
                    result = manager.CreateAsync(user, "12345678").Result;
                    result = manager.AddToRoleAsync(user, roleName).Result;

                    context.Oils.Add(new Oil
                    {
                        Name = "Fuchs Titan Supersyn 5W-40",
                        Type = "Синтетика",
                        Count = 30,
                        Price = 657,
                        Capacity = "4",
                        Description = "Fuchs Titan Supersyn 5W-40 - синтетичне масло для бензинових / дизельних моторів. Розрахованe на ускладнені умови експлуатації. Унікальний склад допоможе захистити від відкладень на елементах двигуна. При дотриманні температурного режиму і не змішуванні з іншими маслами, може подовжити інтервал сервісного обслуговування.",
                        Image = "https://oilteam.com.ua/image/cache/data-fuchs-titan-supersyn-longlife-5w-40-500x500.jpg"
                    });

                    context.Oils.Add(new Oil
                    {
                        Name = "Fuchs Titan Supersyn 5W-40",
                        Type = "Синтетика",
                        Count = 30,
                        Price = 9670,
                        Capacity = "60",
                        Description = "Fuchs Titan Supersyn 5W-40 - синтетичне масло для бензинових / дизельних моторів. Розрахованe на ускладнені умови експлуатації. Унікальний склад допоможе захистити від відкладень на елементах двигуна. При дотриманні температурного режиму і не змішуванні з іншими маслами, може подовжити інтервал сервісного обслуговування.",
                        Image = "https://content1.rozetka.com.ua/goods/images/big/128144379.jpg"
                    });

                    context.Oils.Add(new Oil
                    {
                        Name = "TITAN ATF 6000 SL",
                        Type = "Синтетика",
                        Count = 0,
                        Price = 266,
                        Capacity = "1",
                        Description = "Fuchs TITAN ATF 6000 SL - високоякісна рідина для автоматичних трансмісій легкових автомобілів і легких вантажівок. Висока ефективність продукту гарантує стабільний і всебічний захист вузлів від зносу, мінімальне тертя, економію витрати палива і плавне перемикання передач. Стійке до старіння і окислення, завдяки чому підтримує свої первинні властивості на тривалий термін.",
                        Image = "https://a-static.mlcdn.com.br/618x463/oleo-de-transmissao-fuchs-titan-atf-6000-sl-1l/valerace/9405376525/f79ce59f0d7af3057fbf1b01a01a7e44.jpg"
                    });

                    context.SaveChanges();
                }

            }
            catch { }
        }
    }
}
