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
        public class OptionsBuilder
        {
            public OptionsBuilder()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<SkillIManagerDbContext>();
                optionsBuilder.UseNpgsql(settings.sqlConnectionString);
                dbOptions = optionsBuilder.Options;
            }
            private AppConfiguration settings { get; set; }
            public DbContextOptionsBuilder<SkillIManagerDbContext> optionsBuilder { get; set; }
            public DbContextOptions<SkillIManagerDbContext> dbOptions { get; set; }
        }
        public DbSet<Employee> employees { get; set; }
    }
}
