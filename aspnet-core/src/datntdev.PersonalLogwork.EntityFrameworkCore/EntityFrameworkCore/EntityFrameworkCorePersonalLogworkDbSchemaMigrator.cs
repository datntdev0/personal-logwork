using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using datntdev.PersonalLogwork.Data;
using Volo.Abp.DependencyInjection;

namespace datntdev.PersonalLogwork.EntityFrameworkCore;

public class EntityFrameworkCorePersonalLogworkDbSchemaMigrator
    : IPersonalLogworkDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePersonalLogworkDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the PersonalLogworkDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PersonalLogworkDbContext>()
            .Database
            .MigrateAsync();
    }
}
