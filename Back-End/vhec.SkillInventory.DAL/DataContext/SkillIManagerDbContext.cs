﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Entities;

namespace vhec.SkillInventory.DAL.DataContext
{
    public class SkillIManagerDbContext : DbContext
    {
        public SkillIManagerDbContext(DbContextOptions<SkillIManagerDbContext> options) : base(options)
        {

        }
        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailSkill>()
           .HasKey(e => new { e.IdDetail, e.EmployeeID, e.SkillID });
            modelBuilder.Entity<DetailSkill>()
            .HasOne(pt => pt.Employee)
            .WithMany(p => p.detailSkills)
            .HasForeignKey(pt => pt.EmployeeID);

            modelBuilder.Entity<DetailSkill>()
                .HasOne(pt => pt.Skill)
                .WithMany(t => t.detailSkills)
                .HasForeignKey(pt => pt.SkillID);
        }
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<SkillIManagerDbContext>();
                opsBuilder.UseNpgsql(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            private AppConfiguration settings { get; set; }
            public DbContextOptionsBuilder<SkillIManagerDbContext> opsBuilder { get; set; }
            public DbContextOptions<SkillIManagerDbContext> dbOptions { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();
        public DbSet<Employee> employees { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<DetailSkill> detailSkills { get; set; }
    }
}