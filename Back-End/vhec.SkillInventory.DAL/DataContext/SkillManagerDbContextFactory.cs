using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vhec.SkillInventory.DAL.DataContext
{
    public class SkillManagerDbContextFactory : IDesignTimeDbContextFactory<SkillIManagerDbContext>
    {
        public SkillIManagerDbContext CreateDbContext(string[] args)
        {
            AppConfiguration appconfig = new AppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<SkillIManagerDbContext>();
            optionsBuilder.UseNpgsql(appconfig.sqlConnectionString);
            return new SkillIManagerDbContext(optionsBuilder.Options);
        }
    }
}
