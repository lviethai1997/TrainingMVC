using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Training.Data.EF
{
    public class TrainingDbContextFactory : IDesignTimeDbContextFactory<TrainingDbContext>
    {
        public TrainingDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TraningDb");

            var optionsBuilder = new DbContextOptionsBuilder<TrainingDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TrainingDbContext(optionsBuilder.Options);
        }
    }
}