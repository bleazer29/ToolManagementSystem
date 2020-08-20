using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Roles> Role { get; set; }
        //public DbSet<EmployeeRoles> EmployeeRole { get; set; }
        //public DbSet<RolesPages> RolesPage { get; set; }
        public DbSet<Pages> Page { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Employees employees = new Employees
            //{
            //    Id = 1,
            //    FirstName = "admin",
            //    LastName = "admin",
            //    Patronymic = "admin",
            //    Phone = "00-000-00-00",
            //    BirthDate = DateTime.Now,
            //    UserName = "admin",
            //    Password = "admin",
            //    Question = "Who are you?",
            //    Answer = "admin"
            //};
            //modelBuilder.Entity<Employees>().HasData(employees);

            //Roles roles = new Roles
            //{
            //    Id = 1,
            //    RoleName = "Admin"
            //};
            //modelBuilder.Entity<Roles>().HasData(roles);


            //Pages[] pages =
            //{
            //    new Pages() { Id=1, NamePage="Page1" },
            //    new Pages() { Id=2, NamePage="Page2" },
            //    new Pages() { Id=3, NamePage="Page3" }
            //};
            //modelBuilder.Entity<Pages>().HasData(pages);

            //for (int i = 0; i < pages.Length; i++)
            //{
            //    RolesPages rolesPages = new RolesPages
            //    {
            //        Pages = pages[i],
            //        Roles = roles,
            //        IsVisible = true
            //    };
            //    modelBuilder.Entity<RolesPages>().HasNoKey().HasData(rolesPages);
            //}

            //EmployeeRoles employeeRoles = new EmployeeRoles
            //{
            //    Employe = employees,
            //    Role = roles
            //};
            //modelBuilder.Entity<EmployeeRoles>().HasNoKey().HasData(employeeRoles);
           


        }


    }
}
