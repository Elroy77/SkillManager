using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.DAL.DataContext
{
    public class SkillManagerDbContext : DbContext
    {
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

            //modelBuilder.Entity<Skill>()
            //.HasOne(pt => pt.DetailSkills)
            //.WithMany(t => t.)
            //.HasForeignKey(pt => pt.SkillID);
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<DetailSkill> detailSkills { get; set; }
    }
}
