using Microsoft.EntityFrameworkCore;
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
    }
}
