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
        public DbSet<EmployeeRoles> EmployeeRole { get; set; }
        public DbSet<RolesPages> RolesPage { get; set; }
        public DbSet<Pages> Page { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            Employees employees = new Employees
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Patronymic = "admin",
                Phone = "00-000-00-00",
                BirthDate = DateTime.Now,
                UserName = "admin",
                Password = "admin"
            };
            modelBuilder.Entity<Employees>().HasData(employees);

            Roles roles = new Roles  { Id = 1,  RoleName = "Admin" };
            modelBuilder.Entity<Roles>().HasData(roles);

            Pages[] pages =
            {
                new Pages() { Id=1, NamePage="Page1" },
                new Pages() { Id=2, NamePage="Page2" },
                new Pages() { Id=3, NamePage="Page3" }
            };
            modelBuilder.Entity<Pages>().HasData(pages);

            modelBuilder.Entity<EmployeeRoles>().HasKey(er => new { er.RoleId, er.EmployeeId });
            modelBuilder.Entity<EmployeeRoles>().HasOne(er => er.Employe).WithMany(er => er.EmployeeRoles).HasForeignKey(er => er.EmployeeId);
            modelBuilder.Entity<EmployeeRoles>().HasOne(er => er.Role).WithMany(er => er.EmployeeRoles).HasForeignKey(er => er.RoleId);

            modelBuilder.Entity<EmployeeRoles>().HasData( new EmployeeRoles  { EmployeeId = employees.Id, RoleId = roles.Id/*, IsSelected=true*/ });

            modelBuilder.Entity<RolesPages>().HasKey(rp => new { rp.RoleId, rp.PagesId });
            modelBuilder.Entity<RolesPages>().HasOne(rp => rp.Roles).WithMany(rp => rp.RolesPages).HasForeignKey(rp=> rp.RoleId);
            modelBuilder.Entity<RolesPages>().HasOne(rp => rp.Pages).WithMany(rp => rp.RolesPages).HasForeignKey(rp=> rp.PagesId);

            modelBuilder.Entity<RolesPages>().HasData(
                new RolesPages  { PagesId = pages[0].Id, RoleId = roles.Id/*, IsVisible = true*/ },
                new RolesPages { PagesId = pages[1].Id, RoleId = roles.Id/*, IsVisible = true*/},
                new RolesPages { PagesId = pages[2].Id, RoleId = roles.Id/*, IsVisible = true */});
            




        }

    }
}
