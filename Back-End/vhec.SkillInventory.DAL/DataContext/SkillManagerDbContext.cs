using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.DAL.DataContext
{
    public class SkillManagerDbContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        private User password;

        public SkillManagerDbContext(DbContextOptions<SkillManagerDbContext> options) : base(options)
        {

        }
        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailSkill>()
           .HasKey(e => new { e.IdDetail, e.EmployeeID, e.SkillID });


            modelBuilder.Entity<DetailSkill>()
            .HasOne(pt => pt.Employee)
            .WithMany(dt => dt.DetailSkill)
            .HasForeignKey(pt => new { pt.EmployeeID});


            modelBuilder.Entity<Skill>()
            .HasMany(pt => pt.DetailSkills)
            .WithOne(dt => dt.Skill);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Nguyen",
                    LastName = "Van Manh",
                    Email = "manhnv.dotnet@gmail.com",
                    NormalizedEmail = "MANHNV.DOTNET@GMAIL.COM",
                    PhoneNumber = "0358511226",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = _passwordHasher.HashPassword(password,"Admin@7777$")
                });

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<DetailSkill> detailSkills { get; set; }
    }
}
