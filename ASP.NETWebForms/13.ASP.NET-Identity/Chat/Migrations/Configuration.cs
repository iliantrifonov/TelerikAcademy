namespace Chat.Migrations
{
    using Chat.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Chat.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            AddAdminRole(context);
            AddModeratorRole(context);

            AddInitialAdmin(context);
            AddInitialModerator(context);

            AddInitialMessages(context);
        }

        private void AddInitialMessages(ApplicationDbContext context)
        {
            if (context.Messages.Any())
            {
                return;
            }
            var author = context.Users.FirstOrDefault(u => u.UserName == "admin@gmail.com");

            context.Messages.Add(new Message()
            {
                Author = author,
                DatePublished = DateTime.Now,
                Content = "The admin email is admin@gmail.com, with password 123456"
            });

            context.Messages.Add(new Message()
            {
                Author = author,
                DatePublished = DateTime.Now,
                Content = "The moderator email is moderator@gmail.com, with password 123456"
            });

            context.SaveChanges();
        }

        private void AddInitialAdmin(ApplicationDbContext context)
        {
            string username = "admin@gmail.com";
            string password = "123456";

            var admin = new ApplicationUser()
            {
                UserName = username,
                Email = username,
                FirstName = "Admin"
            };

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!userManager.Users.Any(u => u.UserName == username))
            {
                userManager.Create(admin, password);
                userManager.AddToRole(admin.Id, "Admin");
            }

            context.SaveChanges();
        }

        private void AddInitialModerator(ApplicationDbContext context)
        {
            string username = "moderator@gmail.com";
            string password = "123456";

            var admin = new ApplicationUser()
            {
                UserName = username,
                Email = username,
                FirstName = "Moderator"
            };

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!userManager.Users.Any(u => u.UserName == username))
            {
                userManager.Create(admin, password);
                userManager.AddToRole(admin.Id, "Moderator");
            }

            context.SaveChanges();
        }

        private void AddAdminRole(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string roleName = "Admin";
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }

            context.SaveChanges();
        }

        private void AddModeratorRole(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string roleName = "Moderator";
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }

            context.SaveChanges();
        }
    }
}
