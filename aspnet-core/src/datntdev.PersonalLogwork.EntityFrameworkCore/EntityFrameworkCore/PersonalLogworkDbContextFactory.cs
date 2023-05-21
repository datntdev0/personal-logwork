using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace datntdev.PersonalLogwork.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class PersonalLogworkDbContextFactory : IDesignTimeDbContextFactory<PersonalLogworkDbContext>
{
    public PersonalLogworkDbContext CreateDbContext(string[] args)
    {
        PersonalLogworkEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PersonalLogworkDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new PersonalLogworkDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../datntdev.PersonalLogwork.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
