using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HumanResource.DataAccess
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var path = Directory.GetCurrentDirectory();

            Console.WriteLine($"path:{path}");

            var configuration = new ConfigurationBuilder()
               .SetBasePath(path)
               .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
               .Build();

            var connectionString = configuration["ConnectionString"];

            Console.WriteLine($"connectionString:{connectionString}");

            optionsBuilder.UseNpgsql(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
